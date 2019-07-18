using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using Gar.Root.Contracts;
using INotify.Core;

namespace Gar.Root
{
    public abstract class RootObject : Notifier, IRootObject
    {
        #region fields

        readonly string[] _nonReactantProperties;
        readonly IValidator _validator;

        #endregion

        #region constructors

        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Controlled Scenario")]
        [SuppressMessage("ReSharper", "DoNotCallOverridableMethodsInConstructor", Justification = "Controlled Scenario")]
        protected RootObject()
        {
            _nonReactantProperties = new[]
                                     {
                                         GetName(() => IsValid),
                                         GetName(() => ValidationErrors)
                                     };

            PropertyOf(() => IsValid)
                .DependsOnCollection(() => ValidationErrors);

            PropertyChanged += Validate;

            _validator = GetValidator();
            Validate();
        }

        ~RootObject() => PropertyChanged -= Validate;

        #endregion

        #region properties

        public ExtensionDataObject ExtensionData
        {
            get => GetValue(() => ExtensionData);
            set => SetValue(value, () => ExtensionData);
        }

        public virtual bool IsValid => !(ValidationErrors?.Any() ?? false);

        public NotifyingList<ValidationFailure> ValidationErrors
        {
            get => GetValue(() => ValidationErrors);
            set => SetValue(value, () => ValidationErrors);
        }

        string IDataErrorInfo.Error => string.Empty;

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                var errors = new StringBuilder();

                if (ValidationErrors == null || !ValidationErrors.Any())
                    return errors.ToString();

                foreach (var validationError in ValidationErrors.Where(validationError => validationError.PropertyName == columnName))
                    errors.AppendLine(validationError.ErrorMessage);

                return errors.ToString();
            }
        }

        #endregion

        #region methods

        public void Validate()
        {
            var errors = _validator?.Validate(this)
                                   ?.Errors;

            if (errors != null)
                SetValue(new NotifyingList<ValidationFailure>(errors), () => ValidationErrors);
        }

        protected virtual IValidator GetValidator() => null;

        protected void InvokeForgoValidate(Action action)
        {
            PropertyChanged -= Validate;

            try
            {
                action?.Invoke();
            }
            finally
            {
                PropertyChanged += Validate;
            }
        }

        void Validate(object sender, PropertyChangedEventArgs args)
        {
            if (!_nonReactantProperties.Contains(args.PropertyName))
                Validate();
        }

        #endregion
    }
}
