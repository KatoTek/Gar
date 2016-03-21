using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class CollectionOptionsViewModel : ViewModelRoot, ICollectionOptionsViewModel
    {
        #region properties

        public bool Distinct { get; set; }
        public bool Reversed { get; set; }
        public bool Sorted { get; set; }
        public override string ViewTitle => "Collection Options";

        #endregion
    }
}
