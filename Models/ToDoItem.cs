using System.ComponentModel.DataAnnotations.Schema;
namespace ToDoApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Task { get; set; } = null!;
        public bool IsDone { get; set; }
        public string? enter_date { get; set; }
        public string? Deadline { get; set; }
        // Foreign key to Account
        [Column("account_id")]
        public int AccountId { get; set; }
        // Navigation property to Account
        [ForeignKey("AccountId")]
        public Account? Account { get; set; }
    }
}