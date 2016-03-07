using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static System.Windows.DependencyProperty;

namespace Gar.Root.Ui
{
    public class UserControlViewRoot : UserControl
    {
        #region fields

        private const string VIEW_LOADED = "ViewLoaded";
        public static readonly DependencyProperty ViewLoadedProperty = Register(VIEW_LOADED, typeof(object), typeof(UserControlViewRoot), new PropertyMetadata(null));

        #endregion

        #region constructors

        public UserControlViewRoot()
        {
            // Programmatically bind the view-model's ViewLoaded property to the view's ViewLoaded property.
            BindingOperations.SetBinding(this, ViewLoadedProperty, new Binding(VIEW_LOADED));

            DataContextChanged += OnDataContextChanged;
        }

        #endregion

        #region methods

        protected virtual void OnUnwireViewModelEvents(ViewModelRoot viewModel) {}
        protected virtual void OnWireViewModelEvents(ViewModelRoot viewModel) {}

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                if (e.OldValue != null)
                {
                    // view going out of scope and view-model disconnected (but still around in the parent)
                    // unwire events to allow view to dispose
                    OnUnwireViewModelEvents(e.OldValue as ViewModelRoot);
                }
            }
            else
                OnWireViewModelEvents(e.NewValue as ViewModelRoot);
        }

        #endregion
    }
}
