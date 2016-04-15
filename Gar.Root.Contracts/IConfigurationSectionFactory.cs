using System.Configuration;

namespace Gar.Root.Contracts
{
    public interface IConfigurationSectionFactory<out T> where T : ConfigurationSection
    {
        #region methods

        T GetConfigurationSection(string sectionName);

        #endregion
    }
}
