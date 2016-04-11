using System.Configuration;

namespace Gar.Client.Configuration.Themes
{
    [ConfigurationCollection(typeof(Theme))]
    public class Themes : ConfigurationElementCollection
    {
        #region methods

        protected override ConfigurationElement CreateNewElement() => new Theme();
        protected override object GetElementKey(ConfigurationElement element) => ((Theme)element).Value;

        #endregion
    }
}
