using System;
using System.Linq;
using Encompass.Simple.Extensions;
using Gar.Client.Contracts.ViewModels;
using Gar.Root.Ui;
using INotify;

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
            CopyOutputCommand = new RelayCommand<string>(OnCopyOutputCommandExecute, OnCopyOutputCommandCanExecute);

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
                .DependsOnProperty(() => Collection)
                .DependsOnReferenceProperty(() => SeperatorsViewModel, (ISeperatorsViewModel _) => _.Seperator)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel _) => _.GroupStart)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel _) => _.GroupEnd)
                .DependsOnReferenceProperty(() => GroupersViewModel, (IGroupersViewModel _) => _.Forced);

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
        }

        #endregion

        #region events

        public event EventHandler<string> OutputCopied;

        #endregion

        #region properties

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
        public IDelimitersViewModel DelimitersViewModel => GetValue(() => DelimitersViewModel);
        public IGroupersViewModel GroupersViewModel => GetValue(() => GroupersViewModel);

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
                                Collection.GroupJoin(SeperatorsViewModel?.Seperator, GroupersViewModel?.GroupStart, GroupersViewModel?.GroupEnd, GroupersViewModel?.Forced ?? true));
            }
        }

        public IQualifiersViewModel QualifiersViewModel => GetValue(() => QualifiersViewModel);
        public ISeperatorsViewModel SeperatorsViewModel => GetValue(() => SeperatorsViewModel);
        public override string ViewTitle => "Collections";

        #endregion

        #region methods

        bool OnCopyOutputCommandCanExecute(string obj) => Output.IsNotNullAndNotEmpty();
        void OnCopyOutputCommandExecute(string obj) => OutputCopied?.Invoke(this, Output);

        #endregion
    }
}
