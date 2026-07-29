using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Buildings.Services;
using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Buildings.Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        private readonly DiContainer _container;
        private readonly IBuildingService _buildingService;

        public BuildingFactory(
            DiContainer container,
            IBuildingService buildingService)
        {
            _container = container;
            _buildingService = buildingService;
        }
        public Building Create(BuildingData data, Vector3 position)
        {
            Building building = _container.InstantiatePrefabForComponent<Building>(
                data.BuildingPrefab,
                position,
                Quaternion.identity,
                null);

            _buildingService.Register(building);

            return building;
        }
    }
}