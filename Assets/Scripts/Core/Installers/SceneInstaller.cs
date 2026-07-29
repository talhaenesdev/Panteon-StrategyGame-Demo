using PanteonStrategyGame.Buildings.Controllers;
using PanteonStrategyGame.Buildings.Factories;
using PanteonStrategyGame.Buildings.Services;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.Grid;
using PanteonStrategyGame.Pathfinding;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntitySelectedSignal>().AsSingle();
            Container.BindInterfacesAndSelfTo<EntityDestroyedSignal>().AsSingle();
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
        }
    }
}