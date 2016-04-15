using System.Configuration;
using Gar.Root.Contracts;
using static System.Configuration.ConfigurationManager;

namespace Gar.Root
{
    public class ConfigurationSectionFactory<T> : IConfigurationSectionFactory<T> where T : ConfigurationSection
    {
        #region methods

        public T GetConfigurationSection(string sectionName) => GetSection(sectionName) as T;

        #endregion
    }
}
