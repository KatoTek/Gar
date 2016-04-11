using System.ComponentModel;

namespace Gar.Root.Contracts
{
    public interface ISelectableValue<out T> : INotifyPropertyChanged
    {
        #region properties

        bool IsSelected { get; set; }
        string Text { get; }
        T Value { get; }

        #endregion
    }
}
