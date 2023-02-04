using System.ComponentModel.DataAnnotations;

namespace StudentAccounting.Common.ModelsDto
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}