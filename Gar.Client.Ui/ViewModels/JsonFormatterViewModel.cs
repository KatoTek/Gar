using System;
using Encompass.Simple.Extensions;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify;
using static System.String;
using static Newtonsoft.Json.Formatting;
using static Newtonsoft.Json.JsonConvert;

namespace Gar.Client.Ui.ViewModels
{
    public class JsonFormatterViewModel : ViewModelRoot, IJsonFormatterViewModel
    {
        #region constructors

        public JsonFormatterViewModel()
        {
            ClearInputCommand = new RelayCommand(ClearInputCommandExecute, ClearInputCommandCanExecute);
            CopyOutputCommand = new RelayCommand<string>(CopyOutputCommandExecute, OnCopyOutputCommandCanExecute);

            PropertyOf(() => Output)
                .DependsOnProperty(() => Input);

            PropertyChangeFor(() => Input)
                .Raise(ClearInputCommand);

            PropertyChangeFor(() => Output)
                .Raise(CopyOutputCommand);
        }

        #endregion

        #region events

        public event EventHandler<string> CopyOutput;

        #endregion

        #region properties

        public RelayCommand ClearInputCommand { get; }
        public RelayCommand<string> CopyOutputCommand { get; }

        public string Input
        {
            get { return GetValue(() => Input); }
            set { SetValue(value, () => Input); }
        }

        public string Output
        {
            get
            {
                return GetValue(() => Output,
                                () =>
                                {
                                    try
                                    {
                                        return IsNullOrWhiteSpace(Input)
                                                   ? Empty
                                                   : SerializeObject(DeserializeObject(Input), Indented);
                                    }
                                    catch (Exception exception)
                                    {
                                        return exception.ToText();
                                    }
                                });
            }
        }

        public override string ViewTitle => "JSON";

        #endregion

        #region methods

        bool ClearInputCommandCanExecute() => !IsNullOrEmpty(Input);
        void ClearInputCommandExecute() => Input = Empty;
        void CopyOutputCommandExecute(string obj) => CopyOutput?.Invoke(this, Output);
        bool OnCopyOutputCommandCanExecute(string obj) => !IsNullOrEmpty(Output);

        #endregion
    }
}
