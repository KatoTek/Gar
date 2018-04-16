using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class FormattingToolsViewModel : ViewModelRoot, IFormattingToolsViewModel
    {
        #region constructors

        public FormattingToolsViewModel(ICollectionFormatterViewModel collectionFormatterViewModel, IXmlFormatterViewModel xmlFormatterViewModel, IJsonFormatterViewModel jsonFormatterViewModel)
        {
            InitializeValue(collectionFormatterViewModel, () => CollectionFormatterViewModel);
            InitializeValue(xmlFormatterViewModel, () => XmlFormatterViewModel);
            InitializeValue(jsonFormatterViewModel, () => JsonFormatterViewModel);
        }

        #endregion

        #region properties

        public ICollectionFormatterViewModel CollectionFormatterViewModel => GetValue(() => CollectionFormatterViewModel);
        public IJsonFormatterViewModel JsonFormatterViewModel => GetValue(() => JsonFormatterViewModel);
        public override string ViewTitle => "format";
        public IXmlFormatterViewModel XmlFormatterViewModel => GetValue(() => XmlFormatterViewModel);

        #endregion
    }
}
