using System;
using Gar.Root.Contracts;
using INotify;

namespace Gar.Client.Contracts.ViewModels
{
    public interface ICollectionFormatterViewModel : IViewModelRoot
    {
        #region events

        event EventHandler<string> OutputCopied;

        #endregion

        #region properties

        string[] Collection { get; }
        ICollectionOptionsViewModel CollectionOptionsViewModel { get; }
        RelayCommand<string> CopyOutputCommand { get; }
        IDelimitersViewModel DelimitersViewModel { get; }
        IGroupersViewModel GroupersViewModel { get; }
        string Input { get; set; }
        string Output { get; }
        IQualifiersViewModel QualifiersViewModel { get; }
        ISeperatorsViewModel SeperatorsViewModel { get; }

        #endregion
    }
}
