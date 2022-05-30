using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CINEFLICKS
{
    /* Here we used a pre-defined Aes class which is in System.Security.Cryptography namespace
    that uses the same key for encryption and decryption. AES algorithm supports 128, 198,
     and 256 bit encryption.

    Also, we used initialization vector(IV) which is of 16 bytes in size, the block size of
    the algorithm. IV is optional. */
    
    class clsPassEncryDecry
    {
        // Password encryption
        public string PassEncrypt(string usrPass)
        {
            var EnKey = "s6v9y$B?E(H+MbQeThWmZq4t7w!z%C*F"; // Symmetric key

            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(EnKey);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(usrPass);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        // Password decryption
        public string PassDecrypt(string cipherText)
        {
            var DeKey = "s6v9y$B?E(H+MbQeThWmZq4t7w!z%C*F"; // Symmetric key

            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(DeKey);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}