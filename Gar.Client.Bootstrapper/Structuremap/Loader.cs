using Gar.Client.Bootstrapper.Registries;
using StructureMap;
using static StructureMap.Container;

namespace Gar.Client.Bootstrapper.StructureMap
{
    public static class Loader
    {
        #region methods

        public static IContainer Init() => For<ClientUiRegistry>();

        #endregion
    }
}
