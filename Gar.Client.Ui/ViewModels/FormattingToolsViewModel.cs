using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class FormattingToolsViewModel : ViewModelRoot, IFormattingToolsViewModel
    {
        #region constructors

        public FormattingToolsViewModel(ICollectionFormatterViewModel collectionFormatterViewModel, IXmlFormatterViewModel xmlFormatterViewModel)
        {
            InitializeValue(collectionFormatterViewModel, () => CollectionFormatterViewModel);
            InitializeValue(xmlFormatterViewModel, () => XmlFormatterViewModel);
        }

        #endregion

        #region properties

        public ICollectionFormatterViewModel CollectionFormatterViewModel => GetValue(() => CollectionFormatterViewModel);
        public override string ViewTitle => "Format";
        public IXmlFormatterViewModel XmlFormatterViewModel => GetValue(() => XmlFormatterViewModel);

        #endregion
    }
}
