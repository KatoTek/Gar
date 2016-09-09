using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;

namespace Gar.Client.Design.ViewModels
{
    public class EncodingToolsViewModel : ViewModelRoot, IEncodingToolsViewModel
    {
        #region properties

        public IUrlEncoderViewModel UrlEncoderViewModel => new UrlEncoderViewModel();
        public override string ViewTitle => "encode";

        #endregion
    }
}
