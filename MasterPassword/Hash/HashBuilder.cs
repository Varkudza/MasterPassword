using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace MasterPassword.Hash
{
    public class HashBuilder : IHashBuilder
    {
        public string Build(string str)
        {
            if ((bool)!str?.Equals(""))
            {
                return GetHashString(str);
            }

            return str;
        }

        private byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA512.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}
