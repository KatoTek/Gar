using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class MainViewModel : ViewModelRoot, IMainViewModel
    {
        #region properties

        public IFormattingToolsViewModel FormattingToolsViewModel { get; set; } = new FormattingToolsViewModel();
        public override string ViewTitle => "GAR";

        #endregion
    }
}
