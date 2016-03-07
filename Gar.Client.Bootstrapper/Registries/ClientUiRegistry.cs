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
                     _.WithDefaultConventions();
                 });
        }

        #endregion
    }
}
