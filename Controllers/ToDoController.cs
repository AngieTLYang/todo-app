using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Dtos;
using ToDoApp.Data;
using ToDoApp.Models;
using System.Security.Cryptography;
using System.Text;

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
        var accountId = HttpContext.Session.GetInt32("AccountId");

        if (accountId == null)
            return Unauthorized("User not logged in");

        var todos = await _context.ToDoItems
            .Where(todo => todo.AccountId == accountId)
            .Select(t => new
            {
                t.Id,
                t.Task,
                t.IsDone,
                t.Deadline
            }).ToListAsync();

        return Ok(todos);
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

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ToDoContext _context;

    public AccountController(ToDoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> Get()
    {
        var accounts = await _context.Set<Account>().ToListAsync();
        return Ok(accounts);
    }

    [HttpPost]
    public async Task<ActionResult<Account>> Post(Account account)
    {
        _context.Add(account);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Post), new { id = account.Id }, account);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        Console.WriteLine($"Login attempt: Username={request.Username}, Password={request.Password}");
        var user = _context.Accounts.FirstOrDefault(a => a.Username == request.Username);
        if (user == null)
            return Unauthorized();

        var hashed = ComputeSha256Hash(request.Password);

        if (user.PasswordHash != hashed)
            return Unauthorized();

        HttpContext.Session.SetInt32("AccountId", user.Id);
        HttpContext.Session.SetString("Username", user.Username);

        return Ok(new
        {
            message = "Login successful",
            //accountId = user.Id,
        });
    }

    public string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}