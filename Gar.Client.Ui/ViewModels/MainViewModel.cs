using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class MainViewModel : ViewModelRoot, IMainViewModel
    {
        #region constructors

        public MainViewModel(IFormattingToolsViewModel formattingToolsViewModel)
        {
            FormattingToolsViewModel = formattingToolsViewModel;
        }

        #endregion

        #region properties

        public IFormattingToolsViewModel FormattingToolsViewModel { get; set; }
        public override string ViewTitle => "GAR";

        #endregion
    }
}
