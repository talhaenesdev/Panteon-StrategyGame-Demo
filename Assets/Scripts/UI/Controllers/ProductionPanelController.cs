using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.UI.Interfaces;
using PanteonStrategyGame.UI.Views;
using System;
using System.Collections.Generic;
using Zenject;

namespace PanteonStrategyGame.UI.Controllers
{
    public class ProductionPanelController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly ProductionPanelView _view;
        private readonly IUIFactory _uiFactory;

        private readonly List<ProductionButtonView> _buttons = new();

        private PlayerBarracks _selectedBarracks;

        public ProductionPanelController(
            SignalBus signalBus,
            ProductionPanelView view,
            IUIFactory uiFactory)
        {
            _signalBus = signalBus;
            _view = view;
            _uiFactory = uiFactory;
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
            if (signal.SelectedEntity is PlayerBarracks barracks)
            {
                _selectedBarracks = barracks;

                if (barracks.Team != Team.Player)
                {
                    _view.Hide();
                    return;
                }

                _view.Show();

                BuildButtons(barracks);

                return;
            }

            _selectedBarracks = null;

            ClearButtons();

            _view.Hide();
        }

        private void BuildButtons(PlayerBarracks barracks)
        {
            ClearButtons();

            foreach (var unit in barracks.ProducibleUnits)
            {
                ProductionButtonView button =
                    _uiFactory.CreateProductionButton(
                        _view.ButtonContainer);

                button.Initialize(
                    unit.DisplayName,
                    unit.Icon,
                    () => barracks.ProductionComponent.Produce(unit));

                _buttons.Add(button);
            }
        }

        private void ClearButtons()
        {
            foreach (ProductionButtonView button in _buttons)
            {
                _uiFactory.Release(button.gameObject);
            }

            _buttons.Clear();
        }
    }
}