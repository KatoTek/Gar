using System;
using Gar.Root.Contracts;
using INotify;

namespace Gar.Client.Contracts.ViewModels
{
    public interface IXmlFormatterViewModel : IViewModelRoot
    {
        #region events

        event EventHandler<string> OutputCopied;

        #endregion

        #region properties

        RelayCommand ClearInputCommand { get; }
        RelayCommand<string> CopyOutputCommand { get; }
        RelayCommand FormatInputCommand { get; }
        string Input { get; set; }
        string Output { get; }

        #endregion
    }
}
