using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class CollectionOptionsViewModel : ViewModelRoot, ICollectionOptionsViewModel
    {
        #region properties

        public bool Distinct
        {
            get => GetValue(() => Distinct);
            set => SetValue(value, () => Distinct);
        }

        public bool Reversed
        {
            get => GetValue(() => Reversed);
            set => SetValue(value, () => Reversed);
        }

        public bool Sorted
        {
            get => GetValue(() => Sorted);
            set => SetValue(value, () => Sorted);
        }

        public override string ViewTitle => "collection options";

        #endregion
    }
}
