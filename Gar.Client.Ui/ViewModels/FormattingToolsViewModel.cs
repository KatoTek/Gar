using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class FormattingToolsViewModel : ViewModelRoot, IFormattingToolsViewModel
    {
        #region constructors

        public FormattingToolsViewModel(ICollectionFormatterViewModel collectionFormatterViewModel)
        {
            CollectionFormatterViewModel = collectionFormatterViewModel;
        }

        #endregion

        #region properties

        public ICollectionFormatterViewModel CollectionFormatterViewModel { get; set; }
        public override string ViewTitle => "Formatting";

        #endregion
    }
}
