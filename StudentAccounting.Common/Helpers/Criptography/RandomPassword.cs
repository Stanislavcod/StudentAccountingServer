using System.Text;

namespace StudentAccounting.Common.Helpers.Criptography
{
    public static class RandomPassword
    {
        public static string RandomUserPassword()
        {
            var random = new Random();
            var passwordLength = random.Next(8, 12);
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var sb = new StringBuilder();
            
            for (int i = 0; i < passwordLength; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }
            
            return sb.ToString();
        }
    }
}
