using System;
using Gar.Root.Contracts;

namespace Gar.Root.EventArguments
{
    public class SelectedValueEventArgs<T> : EventArgs
    {
        #region constructors

        public SelectedValueEventArgs(ISelectableValue<T> selectableValue)
        {
            Text = selectableValue.Text;
            Value = selectableValue.Value;
        }

        #endregion

        #region properties

        public string Text { get; }
        public T Value { get; }

        #endregion
    }
}
