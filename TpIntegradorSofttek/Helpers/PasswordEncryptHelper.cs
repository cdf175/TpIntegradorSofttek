using System.Security.Cryptography;
using System.Text;

namespace TpIntegradorSofttek.Helpers
{
    public static class PasswordEncryptHelper
    {
        public static string EncriptPassword(string password) {
            var salt = createSalt();

            string saltAndPwd = string.Concat(password,salt);
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = Array.Empty<byte>();
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(saltAndPwd)); 

            for (int i = 0;i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString(); 
        }

        private static string createSalt()
        {
            var salt = "nTeu3aYA8&xYSw7z#8U54TgN9MLg0c";
            byte[] saltBytes;
            string saltStr;
            saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
            int XORED = 0x00;
            foreach (byte x in saltBytes)
            {
                XORED = XORED ^ x;
            }

            Random random = new Random(XORED);
            saltStr = random.Next().ToString(); 
            saltStr = random.Next().ToString();
            saltStr = random.Next().ToString();
            saltStr = random.Next().ToString();

            return saltStr;
        }


    }
}
