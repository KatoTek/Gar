using System.Linq;
using Gar.Business.Extensions;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using static System.String;

namespace Gar.Client.Ui.ViewModels
{
    public class CollectionFormatterViewModel : ViewModelRoot, ICollectionFormatterViewModel
    {
        #region constructors

        public CollectionFormatterViewModel(IDelimitersViewModel delimitersViewModel, IQualifiersViewModel qualifiersViewModel, ISeperatorsViewModel seperatorsViewModel)
        {
            InitializeValue(delimitersViewModel, () => DelimitersViewModel);
            InitializeValue(qualifiersViewModel, () => QualifiersViewModel);
            InitializeValue(seperatorsViewModel, () => SeperatorsViewModel);

            PropertyOf(() => Collection)
                .DependsOnProperty(() => Input)
                .DependsOnReferenceProperty(() => QualifiersViewModel, (IQualifiersViewModel qvm) => qvm.Qualifier)
                .DependsOnReferenceProperty(() => DelimitersViewModel, (IDelimitersViewModel dvm) => dvm.Delimiters);

            PropertyOf(() => Output)
                .DependsOnProperty(() => Collection)
                .DependsOnReferenceProperty(() => SeperatorsViewModel, (ISeperatorsViewModel svm) => svm.Seperator);

            PropertyChangeFor(() => QualifiersViewModel, (IQualifiersViewModel qvm) => qvm.Qualifier)
                .Execute(() => DelimitersViewModel?.Deselect(QualifiersViewModel?.Qualifier));

            PropertyChangeFor(() => DelimitersViewModel, (IDelimitersViewModel dvm) => dvm.Delimiters)
                .Execute(() => DelimitersViewModel?.Delimiters?.ToList()
                                                   .ForEach(d => QualifiersViewModel?.Deselect(d)));
        }

        #endregion

        #region properties

        public string[] Collection => GetValue(() => Collection, () => Input.Words(QualifiersViewModel?.Qualifier, DelimitersViewModel?.Delimiters));
        public IDelimitersViewModel DelimitersViewModel => GetValue(() => DelimitersViewModel);

        public string Input
        {
            get { return GetValue(() => Input); }
            set { SetValue(value, () => Input); }
        }

        public string Output => GetValue(() => Output,
                                         () => Join(IsNullOrEmpty(SeperatorsViewModel.Seperator)
                                                        ? Empty
                                                        : SeperatorsViewModel.Seperator,
                                                    Collection));

        public IQualifiersViewModel QualifiersViewModel => GetValue(() => QualifiersViewModel);
        public ISeperatorsViewModel SeperatorsViewModel => GetValue(() => SeperatorsViewModel);
        public override string ViewTitle => "Collections";

        #endregion
    }
}
