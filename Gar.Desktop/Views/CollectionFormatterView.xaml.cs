using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using static System.Windows.Clipboard;

namespace Gar.Desktop.Views
{
    public partial class CollectionFormatterView
    {
        #region constructors

        public CollectionFormatterView()
        {
            InitializeComponent();
        }

        #endregion

        #region methods

        protected override void OnUnwireViewModelEvents(ViewModelRoot viewModel)
        {
            var collectionFormatterViewModel = viewModel as ICollectionFormatterViewModel;
            if (collectionFormatterViewModel != null)
                collectionFormatterViewModel.OutputCopied -= OnOutputCopied;
        }

        protected override void OnWireViewModelEvents(ViewModelRoot viewModel)
        {
            var collectionFormatterViewModel = viewModel as ICollectionFormatterViewModel;
            if (collectionFormatterViewModel != null)
                collectionFormatterViewModel.OutputCopied += OnOutputCopied;
        }

        static void OnOutputCopied(object sender, string e) => SetText(e);

        #endregion
    }
}
