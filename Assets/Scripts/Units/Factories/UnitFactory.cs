using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Pooling;
using PanteonStrategyGame.Units.Data;
using PanteonStrategyGame.Units.Models;
using PanteonStrategyGame.Units.Services;
using UnityEngine;

namespace PanteonStrategyGame.Units.Factories
{
    public class UnitFactory : IUnitFactory
    {
        private readonly PoolManager _poolManager;
        private readonly IUnitService _unitService;

        public UnitFactory(
            PoolManager poolManager,
            IUnitService unitService)
        {
            _poolManager = poolManager;
            _unitService = unitService;
        }

        public Unit Create(
            UnitData data,
            Vector3 position)
        {
            GameObject pooledObject =
                _poolManager.Get(data.PoolKey);

            pooledObject.transform.SetPositionAndRotation(
                position,
                Quaternion.identity);

            Unit unit =
                pooledObject.GetComponent<Unit>();

            if (unit == null)
            {
                Debug.LogError(
                    $"Pool '{data.PoolKey}' returned an object without a {nameof(Unit)} component.");

                return null;
            }

            unit.Initialize(data);

            _unitService.Register(unit);

            return unit;
        }
    }
}