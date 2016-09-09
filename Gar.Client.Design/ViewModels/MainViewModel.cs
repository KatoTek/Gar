using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class MainViewModel : ViewModelRoot, IMainViewModel
    {
        #region properties

        public IDecodingToolsViewModel DecodingToolsViewModel { get; } = new DecodingToolsViewModel();
        public IEncodingToolsViewModel EncodingToolsViewModel { get; } = new EncodingToolsViewModel();
        public IFormattingToolsViewModel FormattingToolsViewModel { get; } = new FormattingToolsViewModel();
        public IMainMenuViewModel MainMenuViewModel { get; } = new MainMenuViewModel();
        public override string ViewTitle => "gar";

        #endregion
    }
}
