using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface ICollectionOptionsViewModel : IViewModelRoot
    {
        #region properties

        bool Distinct { get; set; }
        bool Reversed { get; set; }
        bool Sorted { get; set; }

        #endregion
    }
}
