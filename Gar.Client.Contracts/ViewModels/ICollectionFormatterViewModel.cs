using Gar.Client.Contracts.Events;
using Gar.Client.Contracts.Profiles;
using Gar.Root.Contracts;
using INotify;

namespace Gar.Client.Contracts.ViewModels
{
    public interface ICollectionFormatterViewModel : IViewModelRoot,
                                                     IInputOutputViewModel,
                                                     ISqlOutputProfile,
                                                     ICSharpOutputProfile,
                                                     IJsonOutputProfile,
                                                     ICsvOuputProfile,
                                                     ICopyOutput
    {
        #region properties

        string[] Collection { get; }
        ICollectionOptionsViewModel CollectionOptionsViewModel { get; }
        RelayCommand CSharpOutputCommand { get; }
        RelayCommand CsvInputCommand { get; }
        RelayCommand CsvOutputCommand { get; }
        IDelimitersViewModel DelimitersViewModel { get; }
        IGroupersViewModel GroupersViewModel { get; }
        RelayCommand JsonOutputCommand { get; }
        string Prefix { get; set; }
        IQualifiersViewModel QualifiersViewModel { get; }
        ISeperatorsViewModel SeperatorsViewModel { get; }
        RelayCommand SqlOutputCommand { get; }
        string Suffix { get; set; }
        RelayCommand WhitespaceInputCommand { get; }

        #endregion
    }
}
