using PanteonStrategyGame.Core.Signals;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntitySelectedSignal>().AsSingle();
            Container.BindInterfacesAndSelfTo<EntityDestroyedSignal>().AsSingle();
        }
    }
}