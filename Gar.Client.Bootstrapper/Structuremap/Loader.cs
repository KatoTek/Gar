using Gar.Client.Bootstrapper.Registries;
using StructureMap;
using static StructureMap.Container;

namespace Gar.Client.Bootstrapper.Structuremap
{
    public static class Loader
    {
        #region methods

        public static IContainer Init() => For<ClientUiRegistry>();

        #endregion
    }
}
