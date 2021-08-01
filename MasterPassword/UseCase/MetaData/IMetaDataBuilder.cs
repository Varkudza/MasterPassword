using System;
using System.Collections.Generic;
using System.Text;

namespace MasterPassword.UseCase.MetaData
{
    public interface IMetaDataBuilder
    {
        public string Build(string masterPsw, string domain, string userName, int pswSize);
    }
}
