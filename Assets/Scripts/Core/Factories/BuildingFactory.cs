using UnityEngine;
using Zenject;
using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;

namespace PanteonStrategyGame.Core.Factories
{
    public class BuildingFactory
    {
        private readonly DiContainer _container;

        public BuildingFactory(DiContainer container)
        {
            _container = container;
        }

        public Building Create(BuildingData data, Vector3 position)
        {
            return _container.InstantiatePrefabForComponent<Building>(
                data.Prefab,
                position,
                Quaternion.identity,
                null);
        }
    }
}