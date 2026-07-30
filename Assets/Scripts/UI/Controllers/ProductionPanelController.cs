using System;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.UI.Views;
using Zenject;

namespace PanteonStrategyGame.UI.Controllers
{
    public class ProductionPanelController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly ProductionPanelView _view;

        private Barracks _selectedBarracks;

        public ProductionPanelController(
            SignalBus signalBus,
            ProductionPanelView view)
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
            if (signal.SelectedEntity is Barracks barracks)
            {
                _selectedBarracks = barracks;

                _view.Show();

                BuildButtons(barracks);

                return;
            }

            _selectedBarracks = null;

            _view.Hide();
        }


        private void BuildButtons(Barracks barracks)
        {
            UnityEngine.Debug.Log($"Barracks Null : {barracks == null}");
            UnityEngine.Debug.Log($"ProductionComponent Null : {barracks.ProductionComponent == null}");

            foreach (var unit in barracks.ProducibleUnits)
            {
                UnityEngine.Debug.Log($"Unit : {unit}");
            }
            _view.ClearButtons();

            foreach (var unit in barracks.ProducibleUnits)
            {
                var button = _view.CreateButton();

                button.Initialize(
                    unit.DisplayName,
                    () => barracks.ProductionComponent.Produce(unit));
            }
        }
    }
}