﻿using System.Security.Cryptography;
using System.Text;

namespace SharedContext.Extensions;
public static class StringEstensions
{
    public static string ToMd5(string text)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.AppendFormat("{0:x2}", b);
            
            return sb.ToString();
        }
    }

    public static string ToSha256(string text)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.AppendFormat("{0:x2}", b);

            return sb.ToString();
        }
    }

    //public static string ToBase64(this string text)
    //{
    //    return Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
    //}

    //public static string FromBase64(this string text)
    //{
    //    return Encoding.ASCII.GetString(Convert.FromBase64String(text));
    //}

}
