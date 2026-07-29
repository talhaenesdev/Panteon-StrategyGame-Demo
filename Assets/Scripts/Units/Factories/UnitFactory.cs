using UnityEngine;
using Zenject;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Data;
using PanteonStrategyGame.Units.Models;
using PanteonStrategyGame.Units.Services;

namespace PanteonStrategyGame.Units.Factories
{
    public class UnitFactory : IUnitFactory
    {
        private readonly DiContainer _container;
        private readonly IUnitService _unitService;

        public UnitFactory(
            DiContainer container,
            IUnitService unitService)
        {
            _container = container;
            _unitService = unitService;
        }

        public Unit Create(UnitData data, Vector3 position)
        {
            Unit unit = _container.InstantiatePrefabForComponent<Unit>(
                data.Prefab,
                position,
                Quaternion.identity,
                null);

            unit.Initialize(data);

            _unitService.Register(unit);

            return unit;
        }
    }
}