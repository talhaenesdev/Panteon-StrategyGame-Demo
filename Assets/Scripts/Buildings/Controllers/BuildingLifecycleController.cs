using System;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.Grid;
using Zenject;

namespace PanteonStrategyGame.Buildings.Controllers
{
    public class BuildingLifecycleController
        : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly GridManager _gridManager;

        public BuildingLifecycleController(
            SignalBus signalBus,
            GridManager gridManager)
        {
            _signalBus = signalBus;
            _gridManager = gridManager;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EntityDestroyedSignal>(OnEntityDestroyed);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EntityDestroyedSignal>(OnEntityDestroyed);
        }

        private void OnEntityDestroyed(EntityDestroyedSignal signal)
        {
            if (signal.DestroyedEntity is not Building building)
                return;

            _gridManager.RemoveBuilding(building);
        }
    }
}