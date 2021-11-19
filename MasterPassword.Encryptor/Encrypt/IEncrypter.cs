using System;
using System.Collections.Generic;
using System.Text;

namespace MasterPassword.Encryptor.Encrypt
{
    public interface IEncrypter
    {
        public string Encrypt(string key, string str);
    }
}
