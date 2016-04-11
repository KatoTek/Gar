using System;
using System.Linq;
using Gar.Client.Configuration.Themes;
using Gar.Client.Contracts.Configuration;
using Gar.Client.Contracts.ViewModels;
using Gar.Root;
using Gar.Root.EventArguments;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class MainMenuViewModel : ViewModelRoot, IMainMenuViewModel
    {
        #region constructors

        public MainMenuViewModel(IConfigurationSectionFactory<ThemesSection> themeConfigurationSectionFactory)
        {
            var themesSection = themeConfigurationSectionFactory.GetConfigurationSection("gar.desktop.themes");

            InitializeValue(new SelectableValueList<string>(from Accent accent in themesSection.Accents
                                                            select accent),
                            () => Accents);
            InitializeValue(new SelectableValueList<string>(from Theme theme in themesSection.Themes
                                                            select theme),
                            () => Themes);

            PropertyChangeFor(() => Accents, (SelectableValueList<string> acc) => acc.SelectedItem)
                .Execute(() => AccentUpdated?.Invoke(this, new SelectedValueEventArgs<string>(Accents.SelectedItem)));

            PropertyChangeFor(() => Themes, (SelectableValueList<string> thm) => thm.SelectedItem)
                .Execute(() => ThemeUpdated?.Invoke(this, new SelectedValueEventArgs<string>(Themes.SelectedItem)));
        }

        #endregion

        #region events

        public event EventHandler<SelectedValueEventArgs<string>> AccentUpdated;
        public event EventHandler<SelectedValueEventArgs<string>> ThemeUpdated;

        #endregion

        #region properties

        public SelectableValueList<string> Accents => GetValue(() => Accents);
        public SelectableValueList<string> Themes => GetValue(() => Themes);

        #endregion
    }
}
