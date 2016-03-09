using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface ICollectionFormatterViewModel : IViewModelRoot
    {
        #region properties

        string[] Collection { get; }
        string Input { get; set; }
        string Output { get; }

        #endregion
    }
}
