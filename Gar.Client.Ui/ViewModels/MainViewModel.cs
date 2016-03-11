using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class MainViewModel : ViewModelRoot, IMainViewModel
    {
        #region constructors

        public MainViewModel(IFormattingToolsViewModel formattingToolsViewModel)
        {
            InitializeValue(formattingToolsViewModel, () => FormattingToolsViewModel);
        }

        #endregion

        #region properties

        public IFormattingToolsViewModel FormattingToolsViewModel => GetValue(() => FormattingToolsViewModel);
        public override string ViewTitle => "GAR";

        #endregion
    }
}
