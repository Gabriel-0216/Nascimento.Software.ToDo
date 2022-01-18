using System.Text;

namespace Services.Passwords
{
    public class EncryptPasswords
    {
        public string ToHash(string password)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(password));
        }
        public bool PasswordsMatch(string passwordPlainText, string passwordEncrypted)
        {
            var passwordHash = Convert.ToBase64String(Encoding.ASCII.GetBytes(passwordPlainText));
            if (passwordHash.Equals(passwordEncrypted))
            {
                return true;
            }
            return false;
        }
    }
}
