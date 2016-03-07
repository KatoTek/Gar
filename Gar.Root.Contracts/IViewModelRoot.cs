using System.ComponentModel;
using System.Threading;
using INotify;

namespace Gar.Root.Contracts
{
    public interface IViewModelRoot : INotifyPropertyChanged
    {
        #region properties

        bool ErrorsVisible { get; set; }
        bool IsBusy { get; }
        RelayCommand<object> ToggleErrorsCommand { get; }
        SynchronizationContext UiContext { get; }
        string ValidationSummary { get; }
        bool ValidationSummaryVisible { get; }
        string ViewTitle { get; }

        #endregion
    }
}
