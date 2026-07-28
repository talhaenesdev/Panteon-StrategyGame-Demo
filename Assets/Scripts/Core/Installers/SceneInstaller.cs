using PanteonStrategyGame.Core.Factories;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.Grid;
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
        }
    }
}