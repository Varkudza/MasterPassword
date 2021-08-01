using MasterPassword.Encrypt;
using MasterPassword.Hash;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterPassword.UseCase.MetaData
{
    public class MetaDataBuilder : IMetaDataBuilder
    {
        private readonly IHashBuilder hashBuilder;
        private readonly IEncrypter encrypter;

        public MetaDataBuilder(IHashBuilder hashBuilder, IEncrypter encrypter)
        {
            this.hashBuilder = hashBuilder;
            this.encrypter = encrypter;
        }

        public string Build(string masterPsw, string domain, string userName, int pswSize)
        {
            if ((bool)masterPsw?.Equals("") || (bool)domain?.Equals("") || (bool)userName?.Equals(""))
            {
                return string.Empty;
            }

            string masterPswHash = this.hashBuilder.Build(masterPsw);
            string domainHash = this.hashBuilder.Build(domain);
            string userNameHash = this.hashBuilder.Build(userName);

            string metaString = 
                $"{masterPswHash}-{masterPswHash.Substring(0, pswSize / 2)}-{domain}-{domainHash.Substring(0, pswSize / 3)}-{userName}-{userNameHash.Substring(0, pswSize / 5)}";
            
            return encrypter.Encrypt(masterPswHash, hashBuilder.Build(metaString)).Substring(0, pswSize);
        }

    }
}
