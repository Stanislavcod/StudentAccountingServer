
namespace StudentAccounting.Common.ModelsDto
{
    public class RegisterDto
    {
        public string Login { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
