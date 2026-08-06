using System;
using System.Collections.Generic;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.UI.Interfaces;
using PanteonStrategyGame.UI.Views;
using Zenject;

namespace PanteonStrategyGame.UI.Controllers
{
    public class ProductionQueueController
        : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly ProductionQueueView _view;
        private readonly IUIFactory _uiFactory;

        private readonly List<QueueItemView> _items = new();

        public ProductionQueueController(
            SignalBus signalBus,
            ProductionQueueView view,
            IUIFactory uiFactory)
        {
            _signalBus = signalBus;
            _view = view;
            _uiFactory = uiFactory;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ProductionQueueChangedSignal>(
                OnQueueChanged);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ProductionQueueChangedSignal>(
                OnQueueChanged);

            Clear();
        }

        private void OnQueueChanged(
            ProductionQueueChangedSignal signal)
        {
            Clear();

            foreach (var unit in signal.Queue)
            {
                QueueItemView item =
                    _uiFactory.CreateQueueItem(
                        _view.Container);

                item.Initialize(unit.DisplayName,unit.Icon);

                _items.Add(item);
            }
        }

        private void Clear()
        {
            foreach (QueueItemView item in _items)
            {
                _uiFactory.Release(item.gameObject);
            }

            _items.Clear();
        }
    }
}