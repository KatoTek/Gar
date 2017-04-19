using System;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify.Core.Commands;
using static System.Environment;

namespace Gar.Client.Design.ViewModels
{
    public class XmlFormatterViewModel : ViewModelRoot, IXmlFormatterViewModel
    {
        #region constructors

        public XmlFormatterViewModel()
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
        public string Input { get; set; } = "<xml><node>value</node></xml>";
        public string Output { get; } = $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>{NewLine}<xml>{NewLine}\t<node>{NewLine}\t\tvalue{NewLine}\t</node>{NewLine}</xml>";
        public override string ViewTitle => "xml";

        #endregion

        #region methods

        static void ClearInputCommandExecute() { }
        void CopyOutputCommandExecute(string obj) => CopyOutput?.Invoke(this, Output);

        #endregion
    }
}
