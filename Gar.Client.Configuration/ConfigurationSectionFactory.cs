using System.Configuration;
using Gar.Client.Contracts.Configuration;
using static System.Configuration.ConfigurationManager;

namespace Gar.Client.Configuration
{
    public class ConfigurationSectionFactory<T> : IConfigurationSectionFactory<T> where T : ConfigurationSection
    {
        #region methods

        public T GetConfigurationSection(string sectionName) => GetSection(sectionName) as T;

        #endregion
    }
}
