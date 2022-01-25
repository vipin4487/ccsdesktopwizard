using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SimpleEncryption
{
    public static string Decrypt(string textToDecrypt)
    {
        byte[] salt = Encoding.Default.GetBytes("8#@%sf5dDHasHsd8h");
        Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes("kd834kdDASf94klASF", salt);
        byte[] rgbKey = bytes.GetBytes(0x10);
        byte[] rgbIV = bytes.GetBytes(0x10);
        AesCryptoServiceProvider provider = new AesCryptoServiceProvider();
        byte[] buffer = Convert.FromBase64String(textToDecrypt);
        MemoryStream stream = new MemoryStream();
        CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
        stream2.Write(buffer, 0, buffer.Length);
        stream2.FlushFinalBlock();
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    public static string Encrypt(string textToEncrypt)
    {
        byte[] salt = Encoding.Default.GetBytes("8#@%sf5dDHasHsd8h");
        Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes("kd834kdDASf94klASF", salt);
        byte[] rgbKey = bytes.GetBytes(0x10);
        byte[] rgbIV = bytes.GetBytes(0x10);
        AesCryptoServiceProvider provider = new AesCryptoServiceProvider();
        byte[] buffer = Encoding.UTF8.GetBytes(textToEncrypt);
        MemoryStream stream = new MemoryStream();
        CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
        stream2.Write(buffer, 0, buffer.Length);
        stream2.FlushFinalBlock();
        return Convert.ToBase64String(stream.ToArray());
    }
}

