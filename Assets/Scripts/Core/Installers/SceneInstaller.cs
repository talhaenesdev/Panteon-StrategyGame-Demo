using PanteonStrategyGame.Core.Pooling;
using PanteonStrategyGame.Core.Services;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Core.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private PoolDatabase poolDatabase;
        [SerializeField] private RuntimeHierarchyService runtimeHierarchyService;

        public override void InstallBindings()
        {
            SignalInstaller.Install(Container);
            CoreInstaller.Install(Container, poolDatabase, runtimeHierarchyService);
            ServiceInstaller.Install(Container);
            FactoryInstaller.Install(Container);
            UIInstaller.Install(Container);
            GameplayInstaller.Install(Container);
        }
    }
}