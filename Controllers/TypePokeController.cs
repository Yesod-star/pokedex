using Microsoft.AspNetCore.Mvc;
using PokeApi.Models;
using PokeApi.Services;
using Type = PokeApi.Models.Type;

namespace PokeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TypePokeController : ControllerBase
{
    private readonly TypePokeService _pokeService;

    public TypePokeController(TypePokeService pokeService) =>
        _pokeService = pokeService;

    [HttpGet]
    public async Task<List<Type>> Get() =>
        await _pokeService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Type>> Get(Guid id)
    {
        var type = await _pokeService.GetAsync(id);

        if (type is null)
        {
            return NotFound();
        }

        return type;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Type newType)
    {
        await _pokeService.CreateAsync(newType);

        return CreatedAtAction(nameof(Get), new { id = newType.Id }, newType);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(Guid id, Type updatedType)
    {
        var type = await _pokeService.GetAsync(id);

        if (type is null)
        {
            return NotFound();
        }

        updatedType.Id = type.Id;

        await _pokeService.UpdateAsync(id, updatedType);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var type = await _pokeService.GetAsync(id);

        if (type is null)
        {
            return NotFound();
        }

        await _pokeService.RemoveAsync(id);

        return NoContent();
    }
}