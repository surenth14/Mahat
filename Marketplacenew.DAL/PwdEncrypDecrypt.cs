using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EncrypDecrypt
{
    public static class PwdEncrypDecrypt
    {
        private const int SaltSize = 16;
        private const int IvSize = 16;

        public static string Encrypt(string EncryptionKey, string password)
        {
            byte[] clearBytes = Encoding.UTF8.GetBytes(password);

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            using (var pdb = new Rfc2898DeriveBytes(EncryptionKey, salt, 100000, HashAlgorithmName.SHA256))
            using (Aes encryptor = Aes.Create())
            {
                encryptor.Key = pdb.GetBytes(32);
                encryptor.GenerateIV();

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.FlushFinalBlock();
                    }

                    byte[] result = new byte[SaltSize + IvSize + ms.Length];
                    Buffer.BlockCopy(salt, 0, result, 0, SaltSize);
                    Buffer.BlockCopy(encryptor.IV, 0, result, SaltSize, IvSize);
                    Buffer.BlockCopy(ms.ToArray(), 0, result, SaltSize + IvSize, (int)ms.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }

        public static string Decrypt(string EncryptionKey, string cipherText)
        {
            byte[] allBytes = Convert.FromBase64String(cipherText);
            byte[] salt = new byte[SaltSize];
            byte[] iv = new byte[IvSize];
            Buffer.BlockCopy(allBytes, 0, salt, 0, SaltSize);
            Buffer.BlockCopy(allBytes, SaltSize, iv, 0, IvSize);
            byte[] cipherBytes = new byte[allBytes.Length - SaltSize - IvSize];
            Buffer.BlockCopy(allBytes, SaltSize + IvSize, cipherBytes, 0, cipherBytes.Length);

            using (var pdb = new Rfc2898DeriveBytes(EncryptionKey, salt, 100000, HashAlgorithmName.SHA256))
            using (Aes encryptor = Aes.Create())
            {
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = iv;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.FlushFinalBlock();
                    }

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}

