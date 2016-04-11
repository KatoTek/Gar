using System.Configuration;

namespace Gar.Client.Contracts.Configuration
{
    public interface IConfigurationSectionFactory<out T> where T : ConfigurationSection
    {
        #region methods

        T GetConfigurationSection(string sectionName);

        #endregion
    }
}
