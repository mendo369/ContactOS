using System.Security.Cryptography;
using System.Text;

namespace AppContactos.Recursos
{
    public class Utilidades
    {
        public static string Encrypt(string texto)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach(byte b in result)
                    //x2 es un formato que nos indica que la cadena debe formatearse en un valor hexadecimal
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
