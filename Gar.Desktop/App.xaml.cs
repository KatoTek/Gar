using System.Windows;
using Gar.Client.Settings;
using Gar.Root.Contracts;
using Gar.Root.EventArguments;
using StructureMap;
using static Gar.Client.Bootstrapper.Structuremap.Loader;
using static MahApps.Metro.ThemeManager;

namespace Gar.Desktop
{
    public partial class App
    {
        #region properties

        internal static IContainer Container { get; private set; }
        internal static ISettingsManager<Theme> ThemeSettingsManager { get; private set; }

        #endregion

        #region methods

        protected override void OnStartup(StartupEventArgs e)
        {
            Container = Init();

            ThemeSettingsManager = Container.GetInstance<ISettingsManager<Theme>>();

            base.OnStartup(e);
        }

        internal static void AccentUpdated(object sender, SelectedValueEventArgs<string> e)
        {
            var theme = ThemeSettingsManager.Get();
            theme.Accent = e.Value;
            ThemeSettingsManager.Set(theme);

            var appStyle = DetectAppStyle(Current);
            ChangeAppStyle(Current, GetAccent(e.Value), GetAppTheme(appStyle.Item1.Name));
        }

        internal static void ThemeUpdated(object sender, SelectedValueEventArgs<string> e)
        {
            var theme = ThemeSettingsManager.Get();
            theme.Name = e.Value;
            ThemeSettingsManager.Set(theme);

            var appStyle = DetectAppStyle(Current);
            ChangeAppStyle(Current, GetAccent(appStyle.Item2.Name), GetAppTheme(e.Value));
        }

        #endregion
    }
}
