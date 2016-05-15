﻿using Gar.Client.Contracts.Events;
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
            var copyOutput = viewModel as ICopyOutput;
            if (copyOutput != null)
                copyOutput.CopyOutput -= HandleCopyOutput;
        }

        protected override void OnWireViewModelEvents(ViewModelRoot viewModel)
        {
            var copyOutput = viewModel as ICopyOutput;
            if (copyOutput != null)
                copyOutput.CopyOutput += HandleCopyOutput;
        }

        static void HandleCopyOutput(object sender, string e) => SetText(e);

        #endregion
    }
}
