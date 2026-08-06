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
        private readonly IRuntimeHierarchyService _runtimeHierarchy;

        public UnitFactory(
            PoolManager poolManager,
            IUnitService unitService,
            IRuntimeHierarchyService runtimeHierarchy)
        {
            _poolManager = poolManager;
            _unitService = unitService;
            _runtimeHierarchy = runtimeHierarchy;
        }

        public Unit Create(
            UnitData data,
            Vector3 position)
        {
            GameObject pooledObject =
                _poolManager.Get(data.PoolKey, _runtimeHierarchy.RuntimeUnits);

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