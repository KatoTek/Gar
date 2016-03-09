using Gar.Business.Extensions;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class CollectionFormatterViewModel : ViewModelRoot, ICollectionFormatterViewModel
    {
        #region constructors

        public CollectionFormatterViewModel()
        {
            PropertyOf(() => Collection).DependsOnProperty(() => Input);
        }

        #endregion

        #region properties

        public string[] Collection => GetValue(() => Collection, () => Input.TrimWithin().WordArray(' '));

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
