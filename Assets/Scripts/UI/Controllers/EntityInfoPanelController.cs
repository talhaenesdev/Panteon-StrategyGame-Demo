using System;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.UI.Views;
using Zenject;

namespace PanteonStrategyGame.UI.Controllers
{
    public class EntityInfoPanelController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly EntityInfoPanelView _view;

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

            _view.Hide();
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EntitySelectedSignal>(OnEntitySelected);
        }

        private void OnEntitySelected(EntitySelectedSignal signal)
        {
            if (signal.SelectedEntity == null)
            {
                _view.Hide();
                return;
            }

            _view.Show();

            _view.Refresh(
                signal.SelectedEntity.DisplayName,
                signal.SelectedEntity.EntityType.ToString(),
                signal.SelectedEntity.CurrentHealth);
        }
    }
}