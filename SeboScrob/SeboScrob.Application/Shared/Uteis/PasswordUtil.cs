using System.Security.Cryptography;
using System.Text;

namespace SeboScrob.Application.Shared.Uteis
{
    public class PasswordUtil
    {
        public string HashPassword (string password)
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);

            var hashedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedPassword);
        }
    }
}
