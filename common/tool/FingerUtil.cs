using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace common.tool
{
    public class FingerUtil
    {
        public static string Encrypt(string source, string key)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //以下两个很重要 ，解决了其它语言结果不一样的问题
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.Zeros;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(source);
                byte[] keyByte = Encoding.UTF8.GetBytes(key);
                des.Key = keyByte;
                des.IV = keyByte;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                //StringBuilder ret = new StringBuilder();
                //foreach (byte b in ms.ToArray())
                //{
                //    ret.AppendFormat("{0:X2}", b);
                //}
                //return ret.ToString();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return source;
            }
            
        }


        public static string Decrypt(string password, string key)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //以下两个很重要 ，解决了其它语言结果不一样的问题
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.Zeros;
                byte[] inputByteArray = Convert.FromBase64String(password);
                byte[] keyByte = Encoding.UTF8.GetBytes(key);
                des.Key = keyByte;
                des.IV = keyByte;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch {
                return password;
            }
        }
    }
}
