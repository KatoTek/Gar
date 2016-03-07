using Gar.Client.Contracts.ViewModels;
using static Gar.Desktop.App;

namespace Gar.Desktop
{
    public partial class MainWindow
    {
        #region constructors

        public MainWindow()
        {
            InitializeComponent();

            MainView.DataContext = Container.GetInstance<IMainViewModel>();
        }

        #endregion
    }
}
