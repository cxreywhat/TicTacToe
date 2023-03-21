using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Invite
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int FromUserId { get; set; }
        public string Status { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
