using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace StudentAccounting.Utilities
{
    public class AuthOptions
    {
        public const string ISSUER = "StudentAccounting";
        public const string AUDIENCE = "StudentAccountingClient"; // потребитель токена
        const string KEY = "nU8zKtMG4QF7VjRgF6bZNhXuD5rPxE9cL3hYm8oBfAjQ";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
