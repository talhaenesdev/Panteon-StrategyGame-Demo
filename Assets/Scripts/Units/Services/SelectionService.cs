using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using Zenject;

namespace PanteonStrategyGame.Units.Services
{
    public class SelectionService : ISelectionService, IInitializable, System.IDisposable
    {
        private readonly SignalBus _signalBus;

        public Entity SelectedEntity { get; private set; }

        public SelectionService(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EntityDestroyedSignal>(OnEntityDestroyed);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EntityDestroyedSignal>(OnEntityDestroyed);
        }

        public void Select(Entity entity)
        {
            if (SelectedEntity == entity)
                return;

            if (SelectedEntity != null)
            {
                SelectedEntity.Deselect();
            }

            SelectedEntity = entity;

            if (SelectedEntity != null)
            {
                SelectedEntity.Select();
            }

            _signalBus.Fire(new EntitySelectedSignal(entity));
        }

        public void ClearSelection()
        {
            if (SelectedEntity != null)
            {
                SelectedEntity.Deselect();
            }

            SelectedEntity = null;

            _signalBus.Fire(new EntitySelectedSignal(null));
        }

        private void OnEntityDestroyed(EntityDestroyedSignal signal)
        {
            if (SelectedEntity == signal.DestroyedEntity)
            {
                SelectedEntity = null;
            }
        }
    }
}