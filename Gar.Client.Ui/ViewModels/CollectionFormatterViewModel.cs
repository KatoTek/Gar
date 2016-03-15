using Gar.Business.Extensions;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class CollectionFormatterViewModel : ViewModelRoot, ICollectionFormatterViewModel
    {
        #region constructors

        public CollectionFormatterViewModel(IDelimitersViewModel delimitersViewModel, IQualifiersViewModel qualifiersViewModel)
        {
            InitializeValue(delimitersViewModel, () => DelimitersViewModel);
            InitializeValue(qualifiersViewModel, () => QualifiersViewModel);

            PropertyOf(() => Collection)
                .DependsOnProperty(() => Input)
                .DependsOnReferenceProperty(() => QualifiersViewModel, (IQualifiersViewModel qvm) => qvm.Qualifier)
                .DependsOnReferenceProperty(() => DelimitersViewModel, (IDelimitersViewModel dvm) => dvm.Delimiters);
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

        public string Output => GetValue(() => Output);
        public IQualifiersViewModel QualifiersViewModel => GetValue(() => QualifiersViewModel);
        public override string ViewTitle => "Collections";

        #endregion
    }
}
