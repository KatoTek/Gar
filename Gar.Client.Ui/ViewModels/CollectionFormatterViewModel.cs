using System;
using System.Linq;
using Encompass.Simple.Extensions;
using Gar.Client.Contracts.Profiles;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify;
using static System.String;

namespace Gar.Client.Ui.ViewModels
{
    public class CollectionFormatterViewModel : ViewModelRoot, ICollectionFormatterViewModel
    {
        #region constructors

        public CollectionFormatterViewModel(IDelimitersViewModel delimitersViewModel,
                                            IQualifiersViewModel qualifiersViewModel,
                                            ISeperatorsViewModel seperatorsViewModel,
                                            IGroupersViewModel groupersViewModel,
                                            ICollectionOptionsViewModel collectionOptionsViewModel)
        {
            ClearInputCommand = new RelayCommand(ClearInputCommandExecute, ClearInputCommandCanExecute);
            CsvInputCommand = new RelayCommand(CsvInputCommandExecute);
            WhitespaceInputCommand = new RelayCommand(WhitespaceInputCommandExecute);
            CopyOutputCommand = new RelayCommand<string>(OnCopyOutputCommandExecute, OnCopyOutputCommandCanExecute);
            SqlOutputCommand = new RelayCommand(SqlOutputCommandExecute);

            InitializeValue(delimitersViewModel, () => DelimitersViewModel);
            InitializeValue(qualifiersViewModel, () => QualifiersViewModel);
            InitializeValue(seperatorsViewModel, () => SeperatorsViewModel);
            InitializeValue(groupersViewModel, () => GroupersViewModel);
            InitializeValue(collectionOptionsViewModel, () => CollectionOptionsViewModel);

            PropertyOf(() => Collection)
                .DependsOnProperty(() => Input)
                .DependsOnReferenceProperty(() => QualifiersViewModel, (IQualifiersViewModel _) => _.Qualifier)
                .DependsOnReferenceProperty(() => DelimitersViewModel, (IDelimitersViewModel _) => _.Delimiters)
                .DependsOnReferenceProperty(() => CollectionOptionsViewModel, (ICollectionOptionsViewModel _) => _.Distinct)
                .DependsOnReferenceProperty(() => CollectionOptionsViewModel, (ICollectionOptionsViewModel _) => _.Reversed)
                .DependsOnReferenceProperty(() => CollectionOptionsViewModel, (ICollectionOptionsViewModel _) => _.Sorted);

            PropertyOf(() => Output)
                .DependsOnProperty(() => Prefix)
                .DependsOnProperty(() => Suffix)
                .DependsOnProperty(() => Collection)
                .DependsOnReferenceProperty(() => SeperatorsViewModel, (ISeperatorsViewModel _) => _.Seperator)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel _) => _.GroupStart)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel _) => _.GroupEnd)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel _) => _.Forced)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel _) => _.Custom)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel _) => _.CustomGroupStart)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel _) => _.CustomGroupEnd);

            PropertyChangeFor(() => QualifiersViewModel, (IQualifiersViewModel _) => _.Qualifier)
                .Execute(() => DelimitersViewModel?.Deselect(QualifiersViewModel?.Qualifier));

            PropertyChangeFor(() => DelimitersViewModel, (IDelimitersViewModel _) => _.Delimiters)
                .Execute(() => DelimitersViewModel?.Delimiters?.ToList()
                                                   .ForEach(_ => QualifiersViewModel?.Deselect(_)));

            PropertyChangeFor(() => GroupersViewModel, (IGroupersViewModel _) => _.GroupStart)
                .Execute(() => SeperatorsViewModel?.Deselect(GroupersViewModel?.GroupStart));

            PropertyChangeFor(() => GroupersViewModel, (IGroupersViewModel _) => _.GroupEnd)
                .Execute(() => SeperatorsViewModel?.Deselect(GroupersViewModel?.GroupEnd));

            PropertyChangeFor(() => SeperatorsViewModel, (ISeperatorsViewModel _) => _.Seperator)
                .Execute(() => SeperatorsViewModel?.Seperator?.ToCharArray()
                                                   .ToList()
                                                   .ForEach(_ => GroupersViewModel?.Deselect(_)));

            PropertyChangeFor(() => Output)
                .Raise(CopyOutputCommand);

            PropertyChangeFor(() => Input)
                .Raise(ClearInputCommand);
        }

        #endregion

        #region events

        public event EventHandler<string> OutputCopied;

        #endregion

        #region properties

        public RelayCommand ClearInputCommand { get; }

        public string[] Collection => GetValue(() => Collection,
                                               () =>
                                               {
                                                   var collection = Input.Words(QualifiersViewModel?.Qualifier, DelimitersViewModel?.Delimiters)
                                                                         .AsEnumerable();

                                                   if (CollectionOptionsViewModel.Distinct)
                                                       collection = collection.Distinct();

                                                   if (CollectionOptionsViewModel.Sorted)
                                                       collection = collection.OrderBy(item => item);

                                                   if (CollectionOptionsViewModel.Reversed)
                                                       collection = collection.Reverse();

                                                   return collection.ToArray();
                                               });

        public ICollectionOptionsViewModel CollectionOptionsViewModel => GetValue(() => CollectionOptionsViewModel);
        public RelayCommand<string> CopyOutputCommand { get; }
        public RelayCommand CsvInputCommand { get; }
        public IDelimitersViewModel DelimitersViewModel => GetValue(() => DelimitersViewModel);
        public IGroupersViewModel GroupersViewModel => GetValue(() => GroupersViewModel);

        public string Input
        {
            get { return GetValue(() => Input); }
            set { SetValue(value, () => Input); }
        }

        public string Output => GetValue(() => Output,
                                         () =>
                                         {
                                             var output = GroupersViewModel?.Custom ?? false
                                                              ? Collection.GroupJoin(SeperatorsViewModel?.Seperator,
                                                                                     GroupersViewModel?.CustomGroupStart,
                                                                                     GroupersViewModel?.CustomGroupEnd)
                                                              : Collection.GroupJoin(SeperatorsViewModel?.Seperator,
                                                                                     GroupersViewModel?.GroupStart,
                                                                                     GroupersViewModel?.GroupEnd,
                                                                                     GroupersViewModel?.Forced ?? true);

                                             return $"{Prefix ?? Empty}{output ?? Empty}{Suffix ?? Empty}";
                                         });

        public string Prefix
        {
            get { return GetValue(() => Prefix); }
            set { SetValue(value, () => Prefix); }
        }

        public IQualifiersViewModel QualifiersViewModel => GetValue(() => QualifiersViewModel);
        public ISeperatorsViewModel SeperatorsViewModel => GetValue(() => SeperatorsViewModel);
        public RelayCommand SqlOutputCommand { get; }

        public string Suffix
        {
            get { return GetValue(() => Suffix); }
            set { SetValue(value, () => Suffix); }
        }

        public override string ViewTitle => "Collections";
        public RelayCommand WhitespaceInputCommand { get; }

        #endregion

        #region methods

        public void SetSqlOutputProfile()
        {
            Prefix = "(";
            Suffix = ")";
        }

        static void SetCsvInputProfile(ICsvInputProfile csvInputProfile) => csvInputProfile.SetCsvInputProfile();
        static void SetSqlOutputProfile(ISqlOutputProfile sqlOutputProfile) => sqlOutputProfile.SetSqlOutputProfile();
        static void SetWhitespaceInputProfile(IWhitespaceInputProfile whitespaceInputProfile) => whitespaceInputProfile.SetWhitespaceInputProfile();
        bool ClearInputCommandCanExecute() => !IsNullOrEmpty(Input);
        void ClearInputCommandExecute() => Input = Empty;

        void CsvInputCommandExecute()
        {
            SetCsvInputProfile(DelimitersViewModel);
            SetCsvInputProfile(QualifiersViewModel);
        }

        bool OnCopyOutputCommandCanExecute(string obj) => !IsNullOrEmpty(Output);
        void OnCopyOutputCommandExecute(string obj) => OutputCopied?.Invoke(this, Output);

        void SqlOutputCommandExecute()
        {
            SetSqlOutputProfile(this);
            SetSqlOutputProfile(SeperatorsViewModel);
            SetSqlOutputProfile(GroupersViewModel);
        }

        void WhitespaceInputCommandExecute()
        {
            SetWhitespaceInputProfile(DelimitersViewModel);
            SetWhitespaceInputProfile(QualifiersViewModel);
        }

        #endregion
    }
}
