using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class EncodingToolsViewModel : ViewModelRoot, IEncodingToolsViewModel
    {
        #region constructors

        public EncodingToolsViewModel(IUrlEncoderViewModel urlEncoderViewModel) => InitializeValue(urlEncoderViewModel, () => UrlEncoderViewModel);

        #endregion

        #region properties

        public IUrlEncoderViewModel UrlEncoderViewModel => GetValue(() => UrlEncoderViewModel);
        public override string ViewTitle => "encode";

        #endregion
    }
}
