using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class FormattingToolsViewModel : ViewModelRoot, IFormattingToolsViewModel
    {
        #region properties

        public ICollectionFormatterViewModel CollectionFormatterViewModel { get; } = new CollectionFormatterViewModel();
        public IJsonFormatterViewModel JsonFormatterViewModel { get; } = new JsonFormatterViewModel();
        public override string ViewTitle => "format";
        public IXmlFormatterViewModel XmlFormatterViewModel { get; } = new XmlFormatterViewModel();

        #endregion
    }
}
