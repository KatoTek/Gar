using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Ui.ViewModels
{
    public class DecodingToolsViewModel : ViewModelRoot, IDecodingToolsViewModel
    {
        #region constructors

        public DecodingToolsViewModel(IUrlDecoderViewModel urlDecoderViewModel) => InitializeValue(urlDecoderViewModel, () => UrlDecoderViewModel);

        #endregion

        #region properties

        public IUrlDecoderViewModel UrlDecoderViewModel => GetValue(() => UrlDecoderViewModel);
        public override string ViewTitle => "decode";

        #endregion
    }
}
