using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Buildings.Services;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Pooling;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        private readonly PoolManager _poolManager;

        private readonly IBuildingService _buildingService;

        public BuildingFactory(
            PoolManager poolManager,
            IBuildingService buildingService)
        {
            _poolManager = poolManager;
            _buildingService = buildingService;
        }

        public Building Create(BuildingData data, Vector3 position)
        {
            GameObject obj =
                _poolManager.Get(data.PoolKey);

            obj.transform.SetPositionAndRotation(
                position,
                Quaternion.identity);

            Building building =
                obj.GetComponent<Building>();

            building.Initialize(data);

            _buildingService.Register(building);

            return building;
        }
    }
}