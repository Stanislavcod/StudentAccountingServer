using System.Text;

namespace StudentAccounting.Common.Helpers.Criptography
{
    public static class RandomPassword
    {
        public static string RandomUserPassword()
        {
            Random random = new Random();
            int passwordLength = random.Next(8, 12);
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < passwordLength; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }
            return sb.ToString();
        }
    }
}
