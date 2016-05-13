﻿using System;
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
            ClearInputCommand = new RelayCommand(ClearInputCommandExecute);
            CsvInputCommand = new RelayCommand(CsvInputCommandExecute);
            WhitespaceInputCommand = new RelayCommand(WhitespaceInputCommandExecute);
            CopyOutputCommand = new RelayCommand<string>(CopyOutputCommandExecute);
            SqlOutputCommand = new RelayCommand(SqlOutputCommandExecute);
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
        public RelayCommand CsvInputCommand { get; }
        public IDelimitersViewModel DelimitersViewModel { get; } = new DelimitersViewModel();
        public IGroupersViewModel GroupersViewModel { get; } = new GroupersViewModel();
        public string Input { get; set; } = $"1000{NewLine}2000{NewLine}3000{NewLine}4000";
        public string Output => "\"1000\",\"2000\",\"3000\",\"4000\"";
        public string Prefix { get; set; } = "select * from table where colum in (";
        public IQualifiersViewModel QualifiersViewModel { get; } = new QualifiersViewModel();
        public ISeperatorsViewModel SeperatorsViewModel { get; } = new SeperatorsViewModel();
        public RelayCommand SqlOutputCommand { get; }
        public string Suffix { get; set; } = ")";
        public override string ViewTitle => "Collections";
        public RelayCommand WhitespaceInputCommand { get; }

        #endregion

        #region methods

        public void SetSqlOutputProfile() {}
        static void ClearInputCommandExecute() {}
        static void CsvInputCommandExecute() {}
        static void SqlOutputCommandExecute() {}
        static void WhitespaceInputCommandExecute() {}
        void CopyOutputCommandExecute(string obj) => OutputCopied?.Invoke(this, Output);

        #endregion
    }
}
