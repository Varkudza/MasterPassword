using System;
using System.Collections.Generic;
using System.Text;

namespace MasterPassword.Encrypt
{
    public interface IEncrypter
    {
        public string Encrypt(string key, string str);
    }
}
