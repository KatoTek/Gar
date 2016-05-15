using Gar.Client.Contracts.Events;
using Gar.Root.Contracts;
using INotify;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IXmlFormatterViewModel : IViewModelRoot, ICopyOutput
    {
        #region properties

        RelayCommand ClearInputCommand { get; }
        RelayCommand<string> CopyOutputCommand { get; }
        string Input { get; set; }
        string Output { get; }

        #endregion
    }
}
