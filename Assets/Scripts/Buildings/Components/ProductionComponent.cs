using System.Collections.Generic;
using System.Linq;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.Units.Components;
using PanteonStrategyGame.Units.Data;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Buildings.Components
{
    [RequireComponent(typeof(Barracks))]
    public class ProductionComponent : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private IUnitFactory _unitFactory;

        [SerializeField] private SpawnPoint spawnPoint;
        [SerializeField] private Barracks _barracks;

        private readonly Queue<ProductionItem> _queue = new();

        public IReadOnlyCollection<UnitData> Queue =>
            _queue.Select(x => x.UnitData).ToList();

        public void Produce(UnitData data)
        {
            _queue.Enqueue(new ProductionItem(data));

            NotifyQueueChanged();
        }

        private void Update()
        {
            if (_queue.Count == 0)
                return;

            ProductionItem current = _queue.Peek();

            current.RemainingTime -= Time.deltaTime;

            if (current.RemainingTime > 0)
                return;

            _unitFactory.Create(
                current.UnitData,
                _barracks.GetSpawnPosition());

            _queue.Dequeue();

            NotifyQueueChanged();
        }

        private void NotifyQueueChanged()
        {
            _signalBus.Fire(
             new ProductionQueueChangedSignal(
                 _barracks,
                 Queue));
        }
    }
}