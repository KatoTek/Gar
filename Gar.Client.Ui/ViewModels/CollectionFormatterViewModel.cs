using Gar.Business.Extensions;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class CollectionFormatterViewModel : ViewModelRoot, ICollectionFormatterViewModel
    {
        #region constructors

        public CollectionFormatterViewModel(IDelimitersViewModel delimitersViewModel)
        {
            InitializeValue(delimitersViewModel, () => DelimitersViewModel);

            PropertyOf(() => Collection).DependsOnProperty(() => Input);
        }

        #endregion

        #region properties

        public string[] Collection => GetValue(() => Collection, () => Input.Words('"', new[] { ' ', '\t', '\r', '\n' }));
        public IDelimitersViewModel DelimitersViewModel => GetValue(() => DelimitersViewModel);

        public string Input
        {
            get { return GetValue(() => Input); }
            set { SetValue(value, () => Input); }
        }

        public string Output => GetValue(() => Output);
        public override string ViewTitle => "Collections";

        #endregion
    }
}
