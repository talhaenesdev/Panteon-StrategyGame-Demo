using PanteonStrategyGame.UI.Controllers;
using PanteonStrategyGame.UI.Views;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public static class UIInstaller
    {
        public static void Install(DiContainer container)
        {
            container.Bind<EntityInfoPanelView>()
                .FromComponentInHierarchy()
                .AsSingle();

            container.Bind<ProductionPanelView>()
                .FromComponentInHierarchy()
                .AsSingle();

            container.Bind<ProductionQueueView>()
                .FromComponentInHierarchy()
                .AsSingle();

            container.Bind<BuildPanelView>()
                .FromComponentInHierarchy()
                .AsSingle();

            container.BindInterfacesTo<EntityInfoPanelController>()
                .AsSingle();

            container.BindInterfacesTo<ProductionPanelController>()
                .AsSingle();

            container.BindInterfacesTo<ProductionQueueController>()
                .AsSingle();
        }
    }
}