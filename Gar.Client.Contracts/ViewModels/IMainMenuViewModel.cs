using System;
using Gar.Root;
using Gar.Root.Contracts;
using Gar.Root.EventArguments;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IMainMenuViewModel : IViewModelRoot
    {
        #region events

        event EventHandler<SelectedValueEventArgs<string>> AccentUpdated;
        event EventHandler<SelectedValueEventArgs<string>> ThemeUpdated;

        #endregion

        #region properties

        SelectableValueList<string> Accents { get; }
        SelectableValueList<string> Themes { get; }

        #endregion

        #region methods

        void SetAccent(string accent);
        void SetTheme(string theme);

        #endregion
    }
}
