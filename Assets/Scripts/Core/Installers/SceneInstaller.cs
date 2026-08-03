using PanteonStrategyGame.Buildings.Controllers;
using PanteonStrategyGame.Buildings.Factories;
using PanteonStrategyGame.Buildings.Services;
using PanteonStrategyGame.Core.Debug;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Pooling;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.Grid;
using PanteonStrategyGame.Pathfinding;
using PanteonStrategyGame.UI.Controllers;
using PanteonStrategyGame.UI.Factories;
using PanteonStrategyGame.UI.Interfaces;
using PanteonStrategyGame.UI.Views;
using PanteonStrategyGame.Units.Factories;
using PanteonStrategyGame.Units.Services;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public class SceneInstaller : MonoInstaller
    {

        [SerializeField]
        private PoolDatabase poolDatabase;

        public override void InstallBindings()
        {

            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<EntitySelectedSignal>();
            Container.DeclareSignal<EntityDestroyedSignal>();
            Container.DeclareSignal<ProductionQueueChangedSignal>();
            Container.DeclareSignal<BuildingPlacementRequestedSignal>();
            Container.DeclareSignal<EntityHealthChangedSignal>();

            Container.BindInterfacesTo<SignalLogger>().AsSingle();

            Container.Bind<GridManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PoolManager>().AsSingle();

            Container.Bind<IBuildingPlacementService>().To<BuildingPlacementService>().AsSingle();
            Container.Bind<IPathfindingService>().To<AStarPathfinder>().AsSingle();
            Container.Bind<IBuildingService>().To<BuildingService>().AsSingle();
            Container.Bind<IUnitService>().To<UnitService>().AsSingle();
            Container.Bind<ISelectionService>().To<SelectionService>().AsSingle();
            Container.Bind<IProductionService>().To<ProductionService>().AsSingle();

            Container.Bind<EntityInfoPanelView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ProductionPanelView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ProductionQueueView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<BuildPanelView>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesTo<EntityInfoPanelController>().AsSingle();
            Container.BindInterfacesTo<ProductionPanelController>().AsSingle();
            Container.BindInterfacesTo<ProductionQueueController>().AsSingle();

            Container.BindInstance(poolDatabase).AsSingle();

            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IBuildingFactory>().To<BuildingFactory>().AsSingle();
            Container.Bind<IUnitFactory>().To<UnitFactory>().AsSingle();
        }
    }
}