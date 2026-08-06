using System.Collections.Generic;
using System.Linq;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.Units.Data;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Buildings.Components
{
    [RequireComponent(typeof(PlayerBarracks))]
    public class ProductionComponent : MonoBehaviour
    {
        [Inject]
        private SignalBus _signalBus;

        [Inject]
        private IUnitFactory _unitFactory;

        [SerializeField]
        private PlayerBarracks _barracks;

        private readonly Queue<ProductionItem> _queue = new();

        public IReadOnlyCollection<UnitData> Queue =>
            _queue.Select(item => item.UnitData).ToList();

        public bool IsProducing =>
            _queue.Count > 0;

        public float RemainingTime =>
            IsProducing
                ? _queue.Peek().RemainingTime
                : 0f;

        public void Produce(UnitData unitData)
        {
            _queue.Enqueue(
                new ProductionItem(unitData));

            NotifyQueueChanged();
        }

        private void Update()
        {
            if (!IsProducing)
                return;

            ProductionItem current =
                _queue.Peek();

            current.RemainingTime -= Time.deltaTime;

            if (current.RemainingTime > 0f)
                return;

            SpawnUnit(current);

            _queue.Dequeue();

            NotifyQueueChanged();
        }

        private void SpawnUnit(
            ProductionItem item)
        {
            _unitFactory.Create(
                item.UnitData,
                _barracks.GetSpawnPosition());
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