using Gar.Client.Contracts.Events;
using Gar.Root.Ui;
using static System.Windows.Clipboard;

namespace Gar.Desktop.Root
{
    public class CopyOutputViewRoot : UserControlViewRoot
    {
        #region methods

        protected override void OnUnWireViewModelEvents(ViewModelRoot viewModel)
        {
            if (viewModel is ICopyOutput copyOutput)
                copyOutput.CopyOutput -= HandleCopyOutput;
        }

        protected override void OnWireViewModelEvents(ViewModelRoot viewModel)
        {
            if (viewModel is ICopyOutput copyOutput)
                copyOutput.CopyOutput += HandleCopyOutput;
        }

        static void HandleCopyOutput(object sender, string e) => SetText(e);

        #endregion
    }
}
