using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IMainViewModel : IViewModelRoot
    {
        #region properties

        IFormattingToolsViewModel FormattingToolsViewModel { get; }

        #endregion
    }
}
