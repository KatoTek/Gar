using Gar.Client.Ui.ViewModels;
using Gar.Root;
using Gar.Root.Contracts;
using StructureMap;

namespace Gar.Client.Bootstrapper.Registries
{
    public class ClientUiRegistry : Registry
    {
        #region constructors

        public ClientUiRegistry() =>
            Scan(_ =>
                 {
                     _.AssemblyContainingType<RootObject>();
                     _.AssemblyContainingType<MainViewModel>();
                     _.AddAllTypesOf(typeof(IConfigurationSectionFactory<>));
                     _.AddAllTypesOf(typeof(ISettingsManager<>));
                     _.WithDefaultConventions();
                 });

        #endregion
    }
}
