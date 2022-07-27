using System.Text;

namespace DMK_TestAppW.Models
{
    public class User
    {
        public User()
        {
            this.Books = new HashSet<Book>();
        }
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}