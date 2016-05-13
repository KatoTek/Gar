using System;
using Gar.Client.Contracts.Profiles;
using Gar.Root.Contracts;
using INotify;

namespace Gar.Client.Contracts.ViewModels
{
    public interface ICollectionFormatterViewModel : IViewModelRoot, ISqlOutputProfile
    {
        #region events

        event EventHandler<string> OutputCopied;

        #endregion

        #region properties

        RelayCommand ClearInputCommand { get; }
        string[] Collection { get; }
        ICollectionOptionsViewModel CollectionOptionsViewModel { get; }
        RelayCommand<string> CopyOutputCommand { get; }
        RelayCommand CsvInputCommand { get; }
        IDelimitersViewModel DelimitersViewModel { get; }
        IGroupersViewModel GroupersViewModel { get; }
        string Input { get; set; }
        string Output { get; }
        string Prefix { get; set; }
        IQualifiersViewModel QualifiersViewModel { get; }
        ISeperatorsViewModel SeperatorsViewModel { get; }
        RelayCommand SqlOutputCommand { get; }
        string Suffix { get; set; }
        RelayCommand WhitespaceInputCommand { get; }

        #endregion
    }
}
