using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Add EF Core with SQLite
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlite("Data Source=todo.db"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();

app.MapControllers();

app.Run();

public class ToDoItem
{
    public int Id { get; set; }
    public string Task { get; set; } = null!;
    public bool IsDone { get; set; }
    public string? enter_date { get; set; } // or DateTime
    public string? Deadline { get; set; }  // or DateTime
}

public class ToDoContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
}
