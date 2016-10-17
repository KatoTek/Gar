using System.ComponentModel;
using System.Runtime.Serialization;
using FluentValidation.Results;
using INotify.Core;

namespace Gar.Root.Contracts
{
    public interface IRootObject : INotifyPropertyChanged, IDataErrorInfo, IExtensibleDataObject
    {
        #region properties

        bool IsValid { get; }
        NotifyingList<ValidationFailure> ValidationErrors { get; set; }

        #endregion
    }
}
