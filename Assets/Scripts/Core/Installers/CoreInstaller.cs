using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Pooling;
using PanteonStrategyGame.Core.Services;
using PanteonStrategyGame.Grid.Managers;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public static class CoreInstaller
    {
        public static void Install(
            DiContainer container,
            PoolDatabase poolDatabase,
            RuntimeHierarchyService runtimeHierarchyService)
        {
            container.BindInterfacesAndSelfTo<GridManager>()
                .FromComponentInHierarchy()
                .AsSingle();

            container.BindInterfacesAndSelfTo<PoolManager>()
                .AsSingle();

            container.Bind<IRuntimeHierarchyService>()
                .FromInstance(runtimeHierarchyService)
                .AsSingle();

            container.BindInstance(poolDatabase)
                .AsSingle();
        }
    }
}