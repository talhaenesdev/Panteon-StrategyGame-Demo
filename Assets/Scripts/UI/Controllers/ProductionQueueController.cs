using System;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.UI.Views;
using Zenject;

namespace PanteonStrategyGame.UI.Controllers
{
    public class ProductionQueueController
        : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly ProductionQueueView _view;

        public ProductionQueueController(
            SignalBus signalBus,
            ProductionQueueView view)
        {
            _signalBus = signalBus;
            _view = view;
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
        }

        private void OnQueueChanged(
            ProductionQueueChangedSignal signal)
        {
            _view.Refresh(signal.Queue);
        }
    }
}