using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Components;
using PanteonStrategyGame.Units.Data;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Buildings.Components
{
    [RequireComponent(typeof(Barracks))]
    public class ProductionComponent : MonoBehaviour
    {
        [SerializeField]
        private SpawnPoint spawnPoint;

        [Inject]
        private IUnitFactory _unitFactory;

        private readonly Queue<ProductionItem> _queue = new();

        public void Produce(UnitData data)
        {
            _queue.Enqueue(new ProductionItem(data));
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
                spawnPoint.transform.position);

            _queue.Dequeue();
        }
    }
}