using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using Zenject;

namespace PanteonStrategyGame.Units.Services
{
    public class SelectionService : ISelectionService
    {
        private readonly SignalBus _signalBus;

        public Entity SelectedEntity { get; private set; }

        public SelectionService(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Select(Entity entity)
        {
            UnityEngine.Debug.Log($"Selected : {entity?.name}");
            if (SelectedEntity == entity)
                return;

            SelectedEntity?.Deselect();

            SelectedEntity = entity;

            SelectedEntity?.Select();

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
    }
}