using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class User
    {
        public int Id { get; private set; }

        [Required]
        public string Username { get; private set; }

        [Required]
        public string PasswordHash { get; private set; }

        public User()
        {
            
        }
        public User(string userName, string passwordHash)
        {
            Username = userName;
            PasswordHash = passwordHash;
        }
    }
}
