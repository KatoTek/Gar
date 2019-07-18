using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static System.Windows.DependencyProperty;

namespace Gar.Root.Ui
{
    public class UserControlViewRoot : UserControl
    {
        #region fields

        const string VIEW_LOADED = "ViewLoaded";
        public static readonly DependencyProperty ViewLoadedProperty = Register(VIEW_LOADED, typeof(object), typeof(UserControlViewRoot), new PropertyMetadata(null));

        #endregion

        #region constructors

        public UserControlViewRoot()
        {
            // Programmatic-ally bind the view-model's ViewLoaded property to the view's ViewLoaded property.
            BindingOperations.SetBinding(this, ViewLoadedProperty, new Binding(VIEW_LOADED));

            DataContextChanged += OnDataContextChanged;
        }

        #endregion

        #region methods

        protected virtual void OnUnWireViewModelEvents(ViewModelRoot viewModel) { }
        protected virtual void OnWireViewModelEvents(ViewModelRoot viewModel) { }

        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is null)
            {
                if (!(e.OldValue is null))
                    OnUnWireViewModelEvents(e.OldValue as ViewModelRoot);
            }
            else
                OnWireViewModelEvents(e.NewValue as ViewModelRoot);
        }

        #endregion
    }
}
