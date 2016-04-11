using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class MainViewModel : ViewModelRoot, IMainViewModel
    {
        #region properties

        public IFormattingToolsViewModel FormattingToolsViewModel { get; } = new FormattingToolsViewModel();
        public IMainMenuViewModel MainMenuViewModel { get; } = new MainMenuViewModel();
        public override string ViewTitle => "GAR";

        #endregion
    }
}
