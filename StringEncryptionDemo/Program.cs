using System;
using System.IO;
using System.Security.Cryptography;

namespace StringEncryptionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string plainText = "This is a secret message.";
            string password = "StrongPassword123";

            string encryptedText = EncryptString(plainText, password);
            Console.WriteLine("Encrypted Text: " + encryptedText);

            string decryptedText = DecryptString(encryptedText, password);
            Console.WriteLine("Decrypted Text: " + decryptedText);
            Console.ReadKey();
        }

        /// <summary>
        /// Encrypt the string
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptString(string plainText, string password)
        {
            byte[] salt = new byte[8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

            using (Aes aes = Aes.Create())
            {
                aes.Key = pdb.GetBytes(32);
                aes.IV = pdb.GetBytes(16);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(salt, 0, salt.Length);

                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Decrypt the text
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DecryptString(string encryptedText, string password)
        {
            byte[] cipherBytes = Convert.FromBase64String(encryptedText);

            byte[] salt = new byte[8];
            Array.Copy(cipherBytes, 0, salt, 0, salt.Length);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

            using (Aes aes = Aes.Create())
            {
                aes.Key = pdb.GetBytes(32);
                aes.IV = pdb.GetBytes(16);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(cipherBytes, salt.Length, cipherBytes.Length - salt.Length))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}