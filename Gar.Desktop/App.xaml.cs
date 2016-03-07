using System.Windows;
using StructureMap;
using static Gar.Client.Bootstrapper.Structuremap.Loader;

namespace Gar.Desktop
{
    public partial class App
    {
        #region properties

        internal static IContainer Container { get; private set; }

        #endregion

        #region methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Container = Init();
        }

        #endregion
    }
}
