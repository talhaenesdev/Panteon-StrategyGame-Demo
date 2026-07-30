using PanteonStrategyGame.Core.Signals;
using System;
using Zenject;

namespace PanteonStrategyGame.Core.Debug
{
    public class SignalLogger : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        public SignalLogger(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EntitySelectedSignal>(OnEntitySelected);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EntitySelectedSignal>(OnEntitySelected);
        }

        private void OnEntitySelected(EntitySelectedSignal signal)
        {
            UnityEngine.Debug.Log($"Selected: {signal.SelectedEntity?.name}");
        }
    }
}