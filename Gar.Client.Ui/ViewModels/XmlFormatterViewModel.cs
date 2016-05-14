using System;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify;
using static System.String;

namespace Gar.Client.Ui.ViewModels
{
    public class XmlFormatterViewModel : ViewModelRoot, IXmlFormatterViewModel
    {
        #region constructors

        public XmlFormatterViewModel()
        {
            ClearInputCommand = new RelayCommand(ClearInputCommandExecute, ClearInputCommandCanExecute);
            FormatInputCommand = new RelayCommand(FormatInputCommandExecute, FormatInputCommandCanExecute);
            CopyOutputCommand = new RelayCommand<string>(CopyOutputCommandExecute);

            PropertyChangeFor(() => Input)
                .Raise(ClearInputCommand)
                .Raise(FormatInputCommand);
        }

        #endregion

        #region events

        public event EventHandler<string> OutputCopied;

        #endregion

        #region properties

        public RelayCommand ClearInputCommand { get; }
        public RelayCommand<string> CopyOutputCommand { get; }
        public RelayCommand FormatInputCommand { get; }

        public string Input
        {
            get { return GetValue(() => Input); }
            set { SetValue(value, () => Input); }
        }

        public string Output
        {
            get { return GetValue(() => Output); }
        }

        public override string ViewTitle => "XML";

        #endregion

        #region methods

        bool ClearInputCommandCanExecute() => !IsNullOrEmpty(Input);
        void ClearInputCommandExecute() => Input = Empty;
        void CopyOutputCommandExecute(string obj) => OutputCopied?.Invoke(this, Output);
        bool FormatInputCommandCanExecute() => !IsNullOrEmpty(Input); //TODO: verify input is xml

        static void FormatInputCommandExecute()
        {
            //TODO: http://stackoverflow.com/questions/1123718/format-xml-string-to-print-friendly-xml-string
        }

        #endregion
    }
}
