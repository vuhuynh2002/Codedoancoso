using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ShopProject.Repository
{
    public class ShopDAO
    {
        private static byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        private static byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        public string Encrypt(string str)
        {
            byte[] textbyte = Encoding.UTF8.GetBytes(str);
            RijndaelManaged rm = new RijndaelManaged();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, rm.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(textbyte, 0, textbyte.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}