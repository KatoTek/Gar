using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IMainViewModel : IViewModelRoot
    {
        #region properties

        IDecodingToolsViewModel DecodingToolsViewModel { get; }
        IEncodingToolsViewModel EncodingToolsViewModel { get; }
        IFormattingToolsViewModel FormattingToolsViewModel { get; }
        IMainMenuViewModel MainMenuViewModel { get; }

        #endregion
    }
}
