using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; private set; }

        public bool IsComplete { get; private set; }

        public int UserId { get; private set; }

        public virtual User User { get; set; }

        public Todo SetUserId(int userId)
        {
            UserId = userId;
            return this;
        }
    }
}

