using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MasterPassword.Encryptor.Encrypt
{
    public class Encrypter : IEncrypter
    {
        public string Encrypt(string key, string str)
        {
            int numberOfBits = 128;
            byte[] iv = new byte[numberOfBits/ 8];
            byte[] array;

            using(RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.BlockSize = numberOfBits;
                rijndaelManaged.IV = iv;
                rijndaelManaged.Key = Encoding.UTF8.GetBytes(key.Substring(0, 32));

                ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV = iv);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(str);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
    }
}
