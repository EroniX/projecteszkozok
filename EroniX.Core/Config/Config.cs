using System.Collections.Generic;
using System.Collections.Specialized;

namespace EroniX.Core.Config
{
    public class Config : IConfig
    {
        private readonly NameValueCollection _nameValueCollection;

        public Config(NameValueCollection nameValueCollection)
        {
            _nameValueCollection = nameValueCollection;
        }

        public string Get(string name)
        {
            return _nameValueCollection[name];
        }

        public static Config Create(IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            var nameValueCollection = new NameValueCollection();
            foreach (var keyValuePair in keyValuePairs)
            {
                nameValueCollection.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return new Config(nameValueCollection);
        }
    }
}
