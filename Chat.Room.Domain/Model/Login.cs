using System.ComponentModel.DataAnnotations;

namespace Chat.Room.Domain.Model
{
    public class Login
    {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Login(long id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}
