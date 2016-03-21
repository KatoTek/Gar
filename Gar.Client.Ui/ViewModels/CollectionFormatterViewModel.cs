using System.Linq;
using Encompass.Simple.Extensions;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class CollectionFormatterViewModel : ViewModelRoot, ICollectionFormatterViewModel
    {
        #region constructors

        public CollectionFormatterViewModel(IDelimitersViewModel delimitersViewModel,
                                            IQualifiersViewModel qualifiersViewModel,
                                            ISeperatorsViewModel seperatorsViewModel,
                                            IGroupersViewModel groupersViewModel)
        {
            InitializeValue(delimitersViewModel, () => DelimitersViewModel);
            InitializeValue(qualifiersViewModel, () => QualifiersViewModel);
            InitializeValue(seperatorsViewModel, () => SeperatorsViewModel);
            InitializeValue(groupersViewModel, () => GroupersViewModel);

            PropertyOf(() => Collection)
                .DependsOnProperty(() => Input)
                .DependsOnReferenceProperty(() => QualifiersViewModel, (IQualifiersViewModel qvm) => qvm.Qualifier)
                .DependsOnReferenceProperty(() => DelimitersViewModel, (IDelimitersViewModel dvm) => dvm.Delimiters);

            PropertyOf(() => Output)
                .DependsOnProperty(() => Collection)
                .DependsOnReferenceProperty(() => SeperatorsViewModel, (ISeperatorsViewModel svm) => svm.Seperator)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel gvm) => gvm.GroupStart)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel gvm) => gvm.GroupEnd)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel gvm) => gvm.Forced);

            PropertyChangeFor(() => QualifiersViewModel, (IQualifiersViewModel qvm) => qvm.Qualifier)
                .Execute(() => DelimitersViewModel?.Deselect(QualifiersViewModel?.Qualifier));

            PropertyChangeFor(() => DelimitersViewModel, (IDelimitersViewModel dvm) => dvm.Delimiters)
                .Execute(() => DelimitersViewModel?.Delimiters?.ToList()
                                                   .ForEach(d => QualifiersViewModel?.Deselect(d)));

            PropertyChangeFor(() => GroupersViewModel, (IGroupersViewModel gvm) => gvm.GroupStart)
                .Execute(() => SeperatorsViewModel?.Deselect(GroupersViewModel?.GroupStart));

            PropertyChangeFor(() => GroupersViewModel, (IGroupersViewModel gvm) => gvm.GroupEnd)
                .Execute(() => SeperatorsViewModel?.Deselect(GroupersViewModel?.GroupEnd));

            PropertyChangeFor(() => SeperatorsViewModel, (ISeperatorsViewModel svm) => svm.Seperator)
                .Execute(() => SeperatorsViewModel?.Seperator?.ToCharArray()
                                                   .ToList()
                                                   .ForEach(@char => GroupersViewModel?.Deselect(@char)));
        }

        #endregion

        #region properties

        public string[] Collection => GetValue(() => Collection, () => Input.Words(QualifiersViewModel?.Qualifier, DelimitersViewModel?.Delimiters));
        public IDelimitersViewModel DelimitersViewModel => GetValue(() => DelimitersViewModel);
        public IGroupersViewModel GroupersViewModel => GetValue(() => GroupersViewModel);

        public string Input
        {
            get { return GetValue(() => Input); }
            set { SetValue(value, () => Input); }
        }

        public string Output
        {
            get
            {
                return GetValue(() => Output,
                                () =>
                                Collection.GroupJoin(SeperatorsViewModel?.Seperator, GroupersViewModel?.GroupStart, GroupersViewModel?.GroupEnd, GroupersViewModel?.Forced ?? true));
            }
        }

        public IQualifiersViewModel QualifiersViewModel => GetValue(() => QualifiersViewModel);
        public ISeperatorsViewModel SeperatorsViewModel => GetValue(() => SeperatorsViewModel);
        public override string ViewTitle => "Collections";

        #endregion
    }
}
