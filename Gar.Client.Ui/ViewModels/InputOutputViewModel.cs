using System;
using Gar.Client.Contracts.Events;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify;
using static System.String;

namespace Gar.Client.Ui.ViewModels
{
    public abstract class InputOutputViewModel : ViewModelRoot, IInputOutputViewModel, ICopyOutput
    {
        #region constructors

        protected InputOutputViewModel()
        {
            ClearInputCommand = new RelayCommand(ClearInputCommandExecute, ClearInputCommandCanExecute);
            CopyOutputCommand = new RelayCommand<string>(CopyOutputCommandExecute, OnCopyOutputCommandCanExecute);

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

        public abstract string Output { get; }

        #endregion

        #region methods

        bool ClearInputCommandCanExecute() => !IsNullOrEmpty(Input);
        void ClearInputCommandExecute() => Input = Empty;
        void CopyOutputCommandExecute(string obj) => CopyOutput?.Invoke(this, Output);
        bool OnCopyOutputCommandCanExecute(string obj) => !IsNullOrEmpty(Output);

        #endregion
    }
}
