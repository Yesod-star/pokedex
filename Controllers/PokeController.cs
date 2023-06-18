using Microsoft.AspNetCore.Mvc;
using PokeApi.Models;
using PokeApi.Services;

namespace PokeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokeController : ControllerBase
{
    private readonly PokeService _pokeService;

    public PokeController(PokeService pokeService) =>
        _pokeService = pokeService;

    [HttpGet]
    public async Task<List<Pokemon>> Get() =>
        await _pokeService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Pokemon>> Get(Guid id)
    {
        var poke = await _pokeService.GetAsync(id);

        if (poke is null)
        {
            return NotFound();
        }

        return poke;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Pokemon newPokemon)
    {
        await _pokeService.CreateAsync(newPokemon);

        return CreatedAtAction(nameof(Get), new { id = newPokemon.Id }, newPokemon);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(Guid id, Pokemon updatedPokemon)
    {
        var poke = await _pokeService.GetAsync(id);

        if (poke is null)
        {
            return NotFound();
        }

        updatedPokemon.Id = poke.Id;

        await _pokeService.UpdateAsync(id, updatedPokemon);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var poke = await _pokeService.GetAsync(id);

        if (poke is null)
        {
            return NotFound();
        }

        await _pokeService.RemoveAsync(id);

        return NoContent();
    }
}