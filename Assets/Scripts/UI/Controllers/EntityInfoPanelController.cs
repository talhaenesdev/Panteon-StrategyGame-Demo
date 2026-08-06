using System;
using PanteonStrategyGame.Combat.Interfaces;
using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.UI.Views;
using Zenject;

namespace PanteonStrategyGame.UI.Controllers
{
    public class EntityInfoPanelController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly EntityInfoPanelView _view;

        private Entity _selectedEntity;

        public EntityInfoPanelController(
            SignalBus signalBus,
            EntityInfoPanelView view)
        {
            _signalBus = signalBus;
            _view = view;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EntitySelectedSignal>(OnEntitySelected);
            _signalBus.Subscribe<EntityHealthChangedSignal>(OnHealthChanged);

            _view.Hide();
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EntitySelectedSignal>(OnEntitySelected);
            _signalBus.Unsubscribe<EntityHealthChangedSignal>(OnHealthChanged);
        }

        private void OnHealthChanged(EntityHealthChangedSignal signal)
        {
            if (_selectedEntity != signal.Entity)
                return;

            if (signal.Entity is not IDamageable damageable)
                return;

            _view.SetHealth(
                damageable.CurrentHealth,
                damageable.MaxHealth);
        }

        private void OnEntitySelected(EntitySelectedSignal signal)
        {
            _selectedEntity = signal.SelectedEntity;

            if (_selectedEntity == null)
            {
                _view.Hide();
                return;
            }

            if (_selectedEntity is not IDamageable damageable)
                return;

            _view.Show();

            _view.Refresh(
                _selectedEntity.DisplayName,
                _selectedEntity.EntityType.ToString(),
                damageable.CurrentHealth,
                damageable.MaxHealth,
                _selectedEntity.Icon);
        }
    }
}