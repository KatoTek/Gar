using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using static System.String;
using static System.Windows.DependencyProperty;
using static System.Windows.FrameworkPropertyMetadataOptions;

namespace Gar.Desktop.Controls
{
    public partial class InputOutputControl
    {
        #region fields

        public static readonly DependencyProperty OutputProperty = Register("Output",
                                                                            typeof(string),
                                                                            typeof(InputOutputControl),
                                                                            new FrameworkPropertyMetadata(Empty, BindsTwoWayByDefault | Journal, null, CoerceText, true, UpdateSourceTrigger.LostFocus));

        public static readonly DependencyProperty InputProperty = Register("Input",
                                                                           typeof(string),
                                                                           typeof(InputOutputControl),
                                                                           new FrameworkPropertyMetadata(Empty, BindsTwoWayByDefault | Journal, null, CoerceText, true, UpdateSourceTrigger.PropertyChanged));

        public static readonly DependencyProperty ClearInputCommandProperty = Register("ClearInputCommand", typeof(ICommand), typeof(InputOutputControl), new FrameworkPropertyMetadata((ICommand)null));
        public static readonly DependencyProperty CopyOutputCommandProperty = Register("CopyOutputCommand", typeof(ICommand), typeof(InputOutputControl), new FrameworkPropertyMetadata((ICommand)null));

        #endregion

        #region constructors

        public InputOutputControl() => InitializeComponent();

        #endregion

        #region properties

        public ICommand ClearInputCommand
        {
            get => (ICommand)GetValue(ClearInputCommandProperty);
            set => SetValue(ClearInputCommandProperty, value);
        }

        public ICommand CopyOutputCommand
        {
            get => (ICommand)GetValue(CopyOutputCommandProperty);
            set => SetValue(CopyOutputCommandProperty, value);
        }

        public string Input
        {
            get => (string)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        public string Output
        {
            get => (string)GetValue(OutputProperty);
            set => SetValue(OutputProperty, value);
        }

        #endregion

        #region methods

        static object CoerceText(DependencyObject d, object value) => value ?? Empty;

        #endregion
    }
}
