using PanteonStrategyGame.Buildings.Controllers;
using PanteonStrategyGame.Buildings.Factories;
using PanteonStrategyGame.Buildings.Services;
using PanteonStrategyGame.Core.Debug;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.Grid;
using PanteonStrategyGame.Pathfinding;
using PanteonStrategyGame.Units.Factories;
using PanteonStrategyGame.Units.Services;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<EntitySelectedSignal>();
            Container.DeclareSignal<EntityDestroyedSignal>();

            Container.BindInterfacesTo<SignalLogger>().AsSingle();

            Container.Bind<IBuildingFactory>()
                .To<BuildingFactory>()
                .AsSingle();
            Container.Bind<GridManager>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.Bind<IBuildingPlacementService>()
                .To<BuildingPlacementService>()
                .AsSingle();
            Container.Bind<IPathfindingService>()
                .To<AStarPathfinder>()
                .AsSingle();
            Container.Bind<IBuildingService>()
                .To<BuildingService>()
                .AsSingle();
            Container.Bind<IUnitService>()
                .To<UnitService>()
                .AsSingle();
            Container.Bind<IUnitFactory>()
                .To<UnitFactory>()
                .AsSingle();
            Container.Bind<ISelectionService>()
                .To<SelectionService>()
                .AsSingle();
            Container.Bind<IProductionService>()
                .To<ProductionService>()
                .AsSingle();
        }
    }
}