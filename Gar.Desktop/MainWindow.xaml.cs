using Gar.Client.Contracts.ViewModels;
using Gar.Client.Settings;
using static System.Windows.Application;
using static Gar.Desktop.App;
using static MahApps.Metro.ThemeManager;

namespace Gar.Desktop
{
    public partial class MainWindow
    {
        #region constructors

        public MainWindow()
        {
            InitializeComponent();

            var mainViewModel = Container.GetInstance<IMainViewModel>();

            var appStyle = DetectAppStyle(Current);
            ThemeSettingsManager.Initialize(new Theme
                                            {
                                                Accent = appStyle?.Item2?.Name ?? mainViewModel.MainMenuViewModel.Accents.FirstItem.Value,
                                                Name = appStyle?.Item1?.Name ?? mainViewModel.MainMenuViewModel.Themes.FirstItem.Value
                                            });

            var theme = ThemeSettingsManager.Get();

            ChangeAppStyle(Current, GetAccent(theme.Accent), GetAppTheme(theme.Name));

            mainViewModel.MainMenuViewModel.SetTheme(theme.Name);
            mainViewModel.MainMenuViewModel.SetAccent(theme.Accent);

            mainViewModel.MainMenuViewModel.ThemeUpdated += ThemeUpdated;
            mainViewModel.MainMenuViewModel.AccentUpdated += AccentUpdated;

            MainView.DataContext = mainViewModel;
        }

        #endregion
    }
}
