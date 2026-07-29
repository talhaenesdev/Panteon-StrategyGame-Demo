using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Components;
using PanteonStrategyGame.Units.Data;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Buildings.Components
{
    public class ProductionQueue : MonoBehaviour, IProductionQueue
    {
        [SerializeField] private SpawnPoint spawnPoint;

        [Inject] private IUnitFactory _unitFactory;

        private readonly Queue<ProductionItem> _queue = new();
        public int QueueCount => _queue.Count;

        public float RemainingTime =>
            _queue.Count > 0
                ? _queue.Peek().RemainingTime
                : 0f;
        public bool IsProducing => _queue.Count > 0;

        private void Update()
        {
            Tick(Time.deltaTime);
        }

        public void Enqueue(UnitData unitData)
        {
            _queue.Enqueue(new ProductionItem(unitData));
        }

        public void Tick(float deltaTime)
        {
            if (_queue.Count == 0)
                return;

            ProductionItem current = _queue.Peek();

            current.RemainingTime -= deltaTime;

            if (current.RemainingTime > 0)
                return;

            _unitFactory.Create(
                current.UnitData,
                spawnPoint.transform.position);

            _queue.Dequeue();
        }
    }
}