using Gar.Client.Contracts.Events;
using Gar.Client.Contracts.Profiles;
using Gar.Root.Contracts;
using INotify.Core.Commands;

namespace Gar.Client.Contracts.ViewModels
{
    public interface ICollectionFormatterViewModel : IViewModelRoot, IInputOutputViewModel, ISqlOutputProfile, ICSharpOutputProfile, IJsonOutputProfile, ICsvOutputProfile, ICopyOutput
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
        ISeparatorsViewModel SeparatorsViewModel { get; }
        RelayCommand SqlOutputCommand { get; }
        string Suffix { get; set; }
        RelayCommand WhitespaceInputCommand { get; }

        #endregion
    }
}
