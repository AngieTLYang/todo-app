using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class Account
    {
        [Key] // Marks this as the primary key
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
        // Optional: you can add more fields here, like Role, IsActive, etc.
    }
}
