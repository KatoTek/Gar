using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface ICollectionFormatterViewModel : IViewModelRoot
    {
        #region properties

        string[] Collection { get; }
        ICollectionOptionsViewModel CollectionOptionsViewModel { get; }
        IDelimitersViewModel DelimitersViewModel { get; }
        IGroupersViewModel GroupersViewModel { get; }
        string Input { get; set; }
        string Output { get; }
        IQualifiersViewModel QualifiersViewModel { get; }
        ISeperatorsViewModel SeperatorsViewModel { get; }

        #endregion
    }
}
