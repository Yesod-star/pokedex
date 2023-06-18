using Microsoft.AspNetCore.Mvc;
using PokeApi.Models;
using PokeApi.Services;

namespace PokeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovePokeController : ControllerBase
{
    private readonly MovePokeService _pokeService;

    public MovePokeController(MovePokeService pokeService) =>
        _pokeService = pokeService;

    [HttpGet]
    public async Task<List<Move>> Get() =>
        await _pokeService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Move>> Get(Guid id)
    {
        var move = await _pokeService.GetAsync(id);

        if (move is null)
        {
            return NotFound();
        }

        return move;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Move newMove)
    {
        await _pokeService.CreateAsync(newMove);

        return CreatedAtAction(nameof(Get), new { id = newMove.Id }, newMove);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(Guid id, Move updatedMove)
    {
        var move = await _pokeService.GetAsync(id);

        if (move is null)
        {
            return NotFound();
        }

        updatedMove.Id = move.Id;

        await _pokeService.UpdateAsync(id, updatedMove);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var move = await _pokeService.GetAsync(id);

        if (move is null)
        {
            return NotFound();
        }

        await _pokeService.RemoveAsync(id);

        return NoContent();
    }
}