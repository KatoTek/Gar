using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class DecodingToolsViewModel : ViewModelRoot, IDecodingToolsViewModel
    {
        #region properties

        public IUrlDecoderViewModel UrlDecoderViewModel => new UrlDecoderViewModel();
        public override string ViewTitle => "decode";

        #endregion
    }
}
