using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using Gar.Root.Contracts;
using INotify;
using static System.Threading.SynchronizationContext;

namespace Gar.Root.Ui
{
    public abstract class ViewModelRoot : RootObject, IViewModelRoot
    {
        #region fields

        private readonly Stack<object> _isBusyStack = new Stack<object>();
        private List<RootObject> _models;

        #endregion

        #region constructors

        protected ViewModelRoot()
        {
            ToggleErrorsCommand = new RelayCommand<object>(OnToggleErrorsCommandExecute, OnToggleErrorsCommandCanExecute);

            PropertyOf(() => ValidationSummary)
                .DependsOnReferenceProperty(() => ValidationErrors, (NotifyingList<ValidationFailure> errors) => errors.Count)
                .DependsOnProperty(() => IsValid);

            PropertyOf(() => ValidationSummaryVisible).DependsOnCollection(() => ValidationErrors);

            PropertyChangeFor(() => IsValid).Raise(ToggleErrorsCommand);
        }

        protected ViewModelRoot(SynchronizationContext uiContext)
            : this()
        {
            UiContext = uiContext;
        }

        #endregion

        #region properties

        public virtual bool ErrorsVisible
        {
            get { return GetValue(() => ErrorsVisible); }
            set { SetValue(value, () => ErrorsVisible); }
        }

        public bool IsBusy
        {
            get { return GetValue(() => IsBusy); }
            private set { SetValue(value, () => IsBusy); }
        }

        public RelayCommand<object> ToggleErrorsCommand { get; }
        public SynchronizationContext UiContext { get; } = Current;

        public virtual string ValidationSummary
        {
            get
            {
                var ret = string.Empty;

                if (ValidationErrors == null)
                    return ret;

                var verb = ValidationErrors.Count == 1 ? "is" : "are";
                var suffix = ValidationErrors.Count == 1 ? string.Empty : "s";

                if (!IsValid)
                    ret = $"There {verb} {ValidationErrors.Count} validation error{suffix}.";

                return ret;
            }
        }

        public virtual bool ValidationSummaryVisible => GetValue(() => ValidationSummaryVisible, () => ValidationErrors?.Any() ?? false);

        public object ViewLoaded
        {
            get
            {
                OnViewLoaded();
                return null;
            }
        }

        public virtual string ViewTitle => string.Empty;

        #endregion

        #region methods

        protected virtual void AddModels(List<RootObject> models) {}

        protected async Task ExecuteBusyActionAsync(Action busyAction)
        {
            if (busyAction != null)
            {
                StartBusy();
                try
                {
                    await Task.Run(busyAction);
                }
                finally
                {
                    StopBusy();
                }
            }
        }

        protected async Task<T> ExecuteBusyActionAsync<T>(Func<T> busyFunc)
        {
            var t = default(T);
            if (busyFunc == null)
                return t;

            StartBusy();
            try
            {
                t = await Task.Run(busyFunc);
            }
            finally
            {
                StopBusy();
            }
            return t;
        }

        protected virtual bool OnToggleErrorsCommandCanExecute(object arg) => !IsValid;
        protected virtual void OnToggleErrorsCommandExecute(object arg) => ErrorsVisible = !ErrorsVisible;
        protected virtual void OnViewLoaded() {}

        protected void ValidateModel()
        {
            if (_models == null)
            {
                _models = new List<RootObject>();
                AddModels(_models);
            }

            var validationErrors = new List<ValidationFailure>();

            if (_models.Count > 0)
            {
                foreach (var modelObject in _models)
                {
                    modelObject?.Validate();

                    if (modelObject != null)
                        validationErrors = validationErrors.Union(modelObject.ValidationErrors).ToList();
                }
            }

            ValidationErrors = new NotifyingList<ValidationFailure>(validationErrors);
        }

        private void StartBusy()
        {
            if (_isBusyStack.Count == 0)
                IsBusy = true;

            _isBusyStack.Push(new { });
        }

        private void StopBusy()
        {
            if (_isBusyStack.Count > 0)
                _isBusyStack.Pop();

            if (_isBusyStack.Count == 0)
                IsBusy = false;
        }

        #endregion
    }
}
