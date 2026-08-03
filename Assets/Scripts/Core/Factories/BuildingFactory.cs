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

        public Building Create(
            BuildingData data,
            Vector3 position,
            Vector2Int originGridPosition)
        {
            GameObject obj =
                _poolManager.Get(data.PoolKey);

            obj.transform.SetPositionAndRotation(
                position,
                Quaternion.identity);

            Building building =
                obj.GetComponent<Building>();

            Debug.Log($"Before Init : {building.CurrentHealth}");

            building.Initialize(
                data,
                originGridPosition);

            Debug.Log($"After Init : {building.CurrentHealth}");

            _buildingService.Register(building);

            return building;
        }
    }
}