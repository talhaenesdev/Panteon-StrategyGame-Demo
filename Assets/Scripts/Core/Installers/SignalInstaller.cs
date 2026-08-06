using PanteonStrategyGame.Core.Debug;
using PanteonStrategyGame.Core.Signals;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public static class SignalInstaller
    {
        public static void Install(DiContainer container)
        {
            SignalBusInstaller.Install(container);

            container.DeclareSignal<EntitySelectedSignal>();
            container.DeclareSignal<EntityDestroyedSignal>();
            container.DeclareSignal<EntityHealthChangedSignal>();
            container.DeclareSignal<ProductionQueueChangedSignal>();
            container.DeclareSignal<BuildingPlacementRequestedSignal>();

#if UNITY_EDITOR
            container.BindInterfacesTo<SignalLogger>().AsSingle();
#endif
        }
    }
}