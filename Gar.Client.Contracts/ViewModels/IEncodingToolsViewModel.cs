using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IEncodingToolsViewModel : IViewModelRoot
    {
        #region properties

        IUrlEncoderViewModel UrlEncoderViewModel { get; }

        #endregion
    }
}
