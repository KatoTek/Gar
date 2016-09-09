using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class CollectionOptionsViewModel : ViewModelRoot, ICollectionOptionsViewModel
    {
        #region properties

        public bool Distinct
        {
            get { return GetValue(() => Distinct); }
            set { SetValue(value, () => Distinct); }
        }

        public bool Reversed
        {
            get { return GetValue(() => Reversed); }
            set { SetValue(value, () => Reversed); }
        }

        public bool Sorted
        {
            get { return GetValue(() => Sorted); }
            set { SetValue(value, () => Sorted); }
        }

        public override string ViewTitle => "collection options";

        #endregion
    }
}
