using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            // Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
            // Container.BindInterfacesAndSelfTo<SelectionService>().AsSingle();
        }
    }
}