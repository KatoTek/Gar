using System.Configuration;

namespace Gar.Client.Configuration.Themes
{
    public class ThemesSection : ConfigurationSection
    {
        #region properties

        [ConfigurationProperty("accents")]
        public Accents Accents => (Accents)this["accents"];

        [ConfigurationProperty("themes")]
        public Themes Themes => (Themes)this["themes"];

        #endregion

        #region methods

        public static ThemesSection GetSection(string sectionName) => ConfigurationManager.GetSection(sectionName) as ThemesSection;

        #endregion
    }
}
