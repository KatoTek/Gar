using System.Configuration;

namespace Gar.Client.Configuration.Themes
{
    [ConfigurationCollection(typeof(Accent))]
    public class Accents : ConfigurationElementCollection
    {
        #region methods

        protected override ConfigurationElement CreateNewElement() => new Accent();
        protected override object GetElementKey(ConfigurationElement element) => ((Accent)element).Value;

        #endregion
    }
}
