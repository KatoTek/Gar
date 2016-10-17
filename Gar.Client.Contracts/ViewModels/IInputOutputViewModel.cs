using INotify.Core.Commands;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IInputOutputViewModel
    {
        #region properties

        RelayCommand ClearInputCommand { get; }
        RelayCommand<string> CopyOutputCommand { get; }
        string Input { get; set; }
        string Output { get; }

        #endregion
    }
}
