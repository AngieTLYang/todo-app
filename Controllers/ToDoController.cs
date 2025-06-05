using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Dtos;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly ToDoContext _context;

    public ToDoController(ToDoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> Get()
    {
        return await _context.ToDoItems.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItem>> Post(ToDoItem item)
    {
        _context.ToDoItems.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.ToDoItems.FindAsync(id);
        if (item == null) return NotFound();

        _context.ToDoItems.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateTodoDto updatedItem)
    {
        var existingItem = await _context.ToDoItems.FindAsync(id);
        if (existingItem == null) return NotFound();

        existingItem.IsDone = updatedItem.IsDone; // Only updating isDone
        await _context.SaveChangesAsync();

        return Ok(existingItem);
    }
}
