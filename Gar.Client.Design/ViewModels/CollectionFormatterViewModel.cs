using System;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify;
using static System.Environment;

namespace Gar.Client.Design.ViewModels
{
    public class CollectionFormatterViewModel : ViewModelRoot, ICollectionFormatterViewModel
    {
        #region constructors

        public CollectionFormatterViewModel()
        {
            CopyOutputCommand = new RelayCommand<string>(CopyOutputCommandExecute);
            ClearInputCommand = new RelayCommand(ClearInputCommandExecute);
        }

        #endregion

        #region events

        public event EventHandler<string> OutputCopied;

        #endregion

        #region properties

        public RelayCommand ClearInputCommand { get; }
        public string[] Collection => new[] { "1000", "2000", "3000", "4000" };
        public ICollectionOptionsViewModel CollectionOptionsViewModel { get; } = new CollectionOptionsViewModel();
        public RelayCommand<string> CopyOutputCommand { get; }
        public IDelimitersViewModel DelimitersViewModel { get; } = new DelimitersViewModel();
        public IGroupersViewModel GroupersViewModel { get; } = new GroupersViewModel();
        public string Input { get; set; } = $"1000{NewLine}2000{NewLine}3000{NewLine}4000";
        public string Output => "\"1000\",\"2000\",\"3000\",\"4000\"";
        public IQualifiersViewModel QualifiersViewModel { get; } = new QualifiersViewModel();
        public ISeperatorsViewModel SeperatorsViewModel { get; } = new SeperatorsViewModel();
        public override string ViewTitle => "Collections";

        #endregion

        #region methods

        static void ClearInputCommandExecute() {}
        void CopyOutputCommandExecute(string obj) => OutputCopied?.Invoke(this, Output);

        #endregion
    }
}
