using PanteonStrategyGame.Buildings.Services;
using PanteonStrategyGame.Common.Interfaces;
using PanteonStrategyGame.Common.Services;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Pathfinding.Services;
using PanteonStrategyGame.Units.Services;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public static class ServiceInstaller
    {
        public static void Install(DiContainer container)
        {
            container.Bind<IPathfindingService>()
                .To<AStarPathfinder>()
                .AsSingle();

            container.Bind<IBuildingPlacementService>()
                .To<BuildingPlacementService>()
                .AsSingle();

            container.Bind<IBuildingService>()
                .To<BuildingService>()
                .AsSingle();

            container.Bind<IUnitService>()
                .To<UnitService>()
                .AsSingle();

            container.BindInterfacesAndSelfTo<SelectionService>()
                .AsSingle();

            container.Bind<IProductionService>()
                .To<ProductionService>()
                .AsSingle();

            container.Bind<IEntitySpawnService>()
                .To<EntitySpawnService>()
                .AsSingle();
        }
    }
}