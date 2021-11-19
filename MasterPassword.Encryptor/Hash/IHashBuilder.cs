using System;
using System.Collections.Generic;
using System.Text;

namespace MasterPassword.Hash
{
    public interface IHashBuilder
    {
        public string Build(string str);
    }
}
