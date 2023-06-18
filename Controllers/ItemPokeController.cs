using Microsoft.AspNetCore.Mvc;
using PokeApi.Models;
using PokeApi.Services;

namespace PokeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemPokeController : ControllerBase
{
    private readonly ItemPokeService _pokeService;

    public ItemPokeController(ItemPokeService pokeService) =>
        _pokeService = pokeService;

    [HttpGet]
    public async Task<List<Item>> Get() =>
        await _pokeService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Item>> Get(Guid id)
    {
        var item = await _pokeService.GetAsync(id);

        if (item is null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Item newItem)
    {
        await _pokeService.CreateAsync(newItem);

        return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(Guid id, Item updatedItem)
    {
        var item = await _pokeService.GetAsync(id);

        if (item is null)
        {
            return NotFound();
        }

        updatedItem.Id = item.Id;

        await _pokeService.UpdateAsync(id, updatedItem);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _pokeService.GetAsync(id);

        if (item is null)
        {
            return NotFound();
        }

        await _pokeService.RemoveAsync(id);

        return NoContent();
    }
}