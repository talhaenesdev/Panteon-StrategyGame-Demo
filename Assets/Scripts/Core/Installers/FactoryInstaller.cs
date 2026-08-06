using PanteonStrategyGame.Buildings.Factories;
using PanteonStrategyGame.Buildings.Services;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.UI.Factories;
using PanteonStrategyGame.UI.Interfaces;
using PanteonStrategyGame.Units.Factories;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public static class FactoryInstaller
    {
        public static void Install(DiContainer container)
        {
            container.Bind<IAttackPositionProvider>()
                .To<AttackPositionProvider>()
                .AsSingle();

            container.Bind<IBuildingFactory>()
                .To<BuildingFactory>()
                .AsSingle();

            container.Bind<IUnitFactory>()
                .To<UnitFactory>()
                .AsSingle();

            container.Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();
        }
    }
}