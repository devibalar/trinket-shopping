using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PasswordGenerator
/// </summary>
public class PasswordGenerator
{
	public PasswordGenerator()
	{
		
	}
    public static string generateHash(string pwd)
    {
        HashAlgorithm hash = null;
        hash = SHA256.Create();
        byte[] hashedvalue = hash.ComputeHash(Encoding.ASCII.GetBytes(pwd));
        return (Convert.ToBase64String(hashedvalue));
    }

    public static string generateSalt()
    {
        Random r = new Random();
        int num = r.Next(0, 1000000);
        return num.ToString();
    }

    public static string RandomString(int size)
    {
        Random random = new Random();
        string input = "abcdefghijklmnopqrstuvwxyz0123456789";
        var chars = Enumerable.Range(0, size)
                               .Select(x => input[random.Next(0, input.Length)]);
        return new string(chars.ToArray());
    }
}
