using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class MainViewModel : ViewModelRoot, IMainViewModel
    {
        #region constructors

        public MainViewModel(IMainMenuViewModel mainMenuViewModel, IFormattingToolsViewModel formattingToolsViewModel, IEncodingToolsViewModel encodingToolsViewModel, IDecodingToolsViewModel decodingToolsViewModel)
        {
            InitializeValue(mainMenuViewModel, () => MainMenuViewModel);
            InitializeValue(formattingToolsViewModel, () => FormattingToolsViewModel);
            InitializeValue(encodingToolsViewModel, () => EncodingToolsViewModel);
            InitializeValue(decodingToolsViewModel, () => DecodingToolsViewModel);
        }

        #endregion

        #region properties

        public IDecodingToolsViewModel DecodingToolsViewModel => GetValue(() => DecodingToolsViewModel);
        public IEncodingToolsViewModel EncodingToolsViewModel => GetValue(() => EncodingToolsViewModel);
        public IFormattingToolsViewModel FormattingToolsViewModel => GetValue(() => FormattingToolsViewModel);
        public IMainMenuViewModel MainMenuViewModel => GetValue(() => MainMenuViewModel);
        public override string ViewTitle => "gar";

        #endregion
    }
}
