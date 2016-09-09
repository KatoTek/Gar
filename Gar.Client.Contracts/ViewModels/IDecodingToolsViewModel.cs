using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IDecodingToolsViewModel : IViewModelRoot
    {
        #region properties

        IUrlDecoderViewModel UrlDecoderViewModel { get; }

        #endregion
    }
}
