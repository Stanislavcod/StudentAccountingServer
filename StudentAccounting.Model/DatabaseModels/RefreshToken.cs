
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Model.DatabaseModels
{
    public class RefreshToken
    {
        public string Id { get; set; } = string.Empty;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
