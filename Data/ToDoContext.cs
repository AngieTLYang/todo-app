using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
        public DbSet<Account> Accounts => Set<Account>();

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
    }
}
