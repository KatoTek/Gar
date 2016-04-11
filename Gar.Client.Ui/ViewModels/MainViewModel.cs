using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class MainViewModel : ViewModelRoot, IMainViewModel
    {
        #region constructors

        public MainViewModel(IMainMenuViewModel mainMenuViewModel, IFormattingToolsViewModel formattingToolsViewModel)
        {
            InitializeValue(mainMenuViewModel, () => MainMenuViewModel);
            InitializeValue(formattingToolsViewModel, () => FormattingToolsViewModel);
        }

        #endregion

        #region properties

        public IFormattingToolsViewModel FormattingToolsViewModel => GetValue(() => FormattingToolsViewModel);
        public IMainMenuViewModel MainMenuViewModel => GetValue(() => MainMenuViewModel);
        public override string ViewTitle => "GAR";

        #endregion
    }
}
