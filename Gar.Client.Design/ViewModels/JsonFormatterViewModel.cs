using System;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify.Core.Commands;

namespace Gar.Client.Design.ViewModels
{
    public class JsonFormatterViewModel : ViewModelRoot, IJsonFormatterViewModel
    {
        #region constructors

        public JsonFormatterViewModel()
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
        public string Input { get; set; } = "{\"name\":\"Bob\",\"age\":21}";
        public string Output { get; } = $"{{\"name\":\"Bob\",{Environment.NewLine}\"age\":21}}";
        public override string ViewTitle => "json";

        #endregion

        #region methods

        static void ClearInputCommandExecute() {}
        void CopyOutputCommandExecute(string obj) => CopyOutput?.Invoke(this, Output);

        #endregion
    }
}
