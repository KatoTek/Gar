using Gar.Client.Configuration.Themes;
using Gar.Client.Contracts.Configuration;
using Gar.Client.Ui.ViewModels;
using StructureMap;

namespace Gar.Client.Bootstrapper.Registries
{
    public class ClientUiRegistry : Registry
    {
        #region constructors

        public ClientUiRegistry()
        {
            Scan(_ =>
                 {
                     _.AssemblyContainingType<MainViewModel>();
                     _.AssemblyContainingType<ThemesSection>();
                     _.AddAllTypesOf(typeof(IConfigurationSectionFactory<>));
                     _.WithDefaultConventions();
                 });
        }

        #endregion
    }
}
