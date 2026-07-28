using UnityEngine;
using Zenject;
using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Core.Interfaces;

namespace PanteonStrategyGame.Buildings.Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        private readonly DiContainer _container;

        public BuildingFactory(DiContainer container)
        {
            _container = container;
        }

        public Building Create(BuildingData data, Vector3 position)
        {
            return _container.InstantiatePrefabForComponent<Building>(
                data.BuildingPrefab,
                position,
                Quaternion.identity,
                null);
        }
    }
}