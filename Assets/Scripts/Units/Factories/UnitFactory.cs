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

        public Unit Create(UnitData data, Vector3 position)
        {
            GameObject obj = _poolManager.Get(data.PoolKey);

            obj.transform.SetPositionAndRotation(
                position,
                Quaternion.identity);

            Unit unit = obj.GetComponent<Unit>();

            unit.Initialize(data);

            _unitService.Register(unit);

            return unit;
        }
    }
}