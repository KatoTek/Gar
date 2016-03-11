using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class FormattingToolsViewModel : ViewModelRoot, IFormattingToolsViewModel
    {
        #region properties

        public ICollectionFormatterViewModel CollectionFormatterViewModel { get; } = new CollectionFormatterViewModel();
        public override string ViewTitle => "Formatting";

        #endregion
    }
}
