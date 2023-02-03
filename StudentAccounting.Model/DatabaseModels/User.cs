
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.Model.DataBaseModels
{
    public class User
    {
        public int Id { get; set; } 
        public string Login { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
        public bool isGlobalPM { get; set; }
        public Participants? Participants { get; set; }
        public List<RefreshToken> RefreshToken { get; set; } = new();
    }
}
