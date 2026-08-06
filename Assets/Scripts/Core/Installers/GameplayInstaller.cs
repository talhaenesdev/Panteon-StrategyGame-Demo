using PanteonStrategyGame.Buildings.Controllers;
using PanteonStrategyGame.Buildings.Placement.Rules;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public static class GameplayInstaller
    {
        public static void Install(DiContainer container)
        {
            container.BindInterfacesTo<BuildingLifecycleController>()
                .AsSingle();

            container.Bind<IPlacementRule>()
                .To<FootprintRule>()
                .AsSingle();

            container.Bind<IPlacementRule>()
                .To<BufferRule>()
                .AsSingle();
        }
    }
}