using System;
using System.Security.Cryptography;

namespace COS
{
    internal class Encoding
    {
        //Key 32
        private static string Key = "@#!VdwX*srde@#!VdwX*srde@#!VdwX*";

        //IV 16
        private static string IV = "Pv3%pf&(skERiv$!";

        public string Encrypt(string text)
        {
            byte[] plaintextbytes = System.Text.Encoding.UTF8.GetBytes(text);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.Encoding.UTF8.GetBytes(Key);
            aes.IV = System.Text.Encoding.UTF8.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plaintextbytes, 0, plaintextbytes.Length);
            crypto.Dispose();
            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string encrypted)
        {
            //try
            //{
            byte[] encryptedbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.Encoding.UTF8.GetBytes(Key);
            aes.IV = System.Text.Encoding.UTF8.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedbytes, 0, encryptedbytes.Length);
            crypto.Dispose();
            return System.Text.Encoding.UTF8.GetString(secret);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}