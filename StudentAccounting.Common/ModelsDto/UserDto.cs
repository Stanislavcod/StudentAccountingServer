
namespace StudentAccounting.Common.ModelsDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public RoleDto? Role { get; set; }
    }
}
