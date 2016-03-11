using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class FormattingToolsViewModel : ViewModelRoot, IFormattingToolsViewModel
    {
        #region constructors

        public FormattingToolsViewModel(ICollectionFormatterViewModel collectionFormatterViewModel)
        {
            InitializeValue(collectionFormatterViewModel, () => CollectionFormatterViewModel);
        }

        #endregion

        #region properties

        public ICollectionFormatterViewModel CollectionFormatterViewModel => GetValue(() => CollectionFormatterViewModel);
        public override string ViewTitle => "Formatting";

        #endregion
    }
}
