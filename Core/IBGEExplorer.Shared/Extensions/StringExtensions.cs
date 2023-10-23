using System.Security.Cryptography;
using System.Text;

namespace IBGEExplorer.Shared.Extensions;

public static class StringExtensions
{
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

    public static string CreateSalt()
    {
        var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        var buff = new byte[15];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }

    public static string GenerateSha256Hash(string salt, string senha) 
        => ToSha256(salt + ToSha256(senha)) ;
}