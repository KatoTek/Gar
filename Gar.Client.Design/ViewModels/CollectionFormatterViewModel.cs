using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using static System.Environment;

namespace Gar.Client.Design.ViewModels
{
    public class CollectionFormatterViewModel : ViewModelRoot, ICollectionFormatterViewModel
    {
        #region properties

        public string[] Collection => new[] { "1000", "2000", "3000", "4000" };
        public ICollectionOptionsViewModel CollectionOptionsViewModel { get; } = new CollectionOptionsViewModel();
        public IDelimitersViewModel DelimitersViewModel { get; } = new DelimitersViewModel();
        public IGroupersViewModel GroupersViewModel { get; } = new GroupersViewModel();
        public string Input { get; set; } = $"1000{NewLine}2000{NewLine}3000{NewLine}4000";
        public string Output => "\"1000\",\"2000\",\"3000\",\"4000\"";
        public IQualifiersViewModel QualifiersViewModel { get; } = new QualifiersViewModel();
        public ISeperatorsViewModel SeperatorsViewModel { get; } = new SeperatorsViewModel();
        public override string ViewTitle => "Collections";

        #endregion
    }
}
