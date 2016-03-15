using Gar.Root.Contracts;

namespace Gar.Client.Contracts.ViewModels
{
    public interface ICollectionFormatterViewModel : IViewModelRoot
    {
        #region properties

        string[] Collection { get; }
        IDelimitersViewModel DelimitersViewModel { get; }
        string Input { get; set; }
        string Output { get; }
        IQualifiersViewModel QualifiersViewModel { get; }

        #endregion
    }
}
