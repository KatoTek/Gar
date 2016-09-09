using System;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify;

namespace Gar.Client.Design.ViewModels
{
    public class UrlEncoderViewModel : ViewModelRoot, IUrlEncoderViewModel
    {
        #region constructors

        public UrlEncoderViewModel()
        {
            ClearInputCommand = new RelayCommand(ClearInputCommandExecute);
            CopyOutputCommand = new RelayCommand<string>(CopyOutputCommandExecute);
        }

        #endregion

        #region events

        public event EventHandler<string> CopyOutput;

        #endregion

        #region properties

        public RelayCommand ClearInputCommand { get; }
        public RelayCommand<string> CopyOutputCommand { get; }
        public string Input { get; set; } = "http://www.google.com";
        public string Output { get; } = "http%3A%2F%2Fwww.google.com";
        public override string ViewTitle => "url";

        #endregion

        #region methods

        static void ClearInputCommandExecute() {}
        void CopyOutputCommandExecute(string obj) => CopyOutput?.Invoke(this, Output);

        #endregion
    }
}
