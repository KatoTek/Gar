using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IFormattingToolsViewModel : IViewModelRoot
    {
        #region properties

        ICollectionFormatterViewModel CollectionFormatterViewModel { get; set; }

        #endregion
    }
}
