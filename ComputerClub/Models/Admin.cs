using System.Text;
using System.Security.Cryptography;

namespace ComputerClub.Models
{
    public class Admin
    {
        public string Login { get; private set; }
        public string Password { get; private set; }


        private Admin(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public Admin(string login, string password, bool isInit = true)
        {
            Login = login;
            Password = ComputeSHA256Hash(password);
        }

        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Преобразуем строку в массив байт
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                // Вычисляем хэш
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Преобразуем массив байт хэша обратно в строку
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); // Преобразование в шестнадцатеричную строку
                }
                return builder.ToString();
            }
        }
    }
}
