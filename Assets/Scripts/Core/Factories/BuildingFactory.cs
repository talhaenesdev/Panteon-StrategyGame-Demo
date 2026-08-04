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
            GameObject pooledObject =
                _poolManager.Get(data.PoolKey);

            pooledObject.transform.SetPositionAndRotation(
                position,
                Quaternion.identity);

            Building building =
                pooledObject.GetComponent<Building>();

            if (building == null)
            {
                Debug.LogError(
                    $"Pool '{data.PoolKey}' returned an object without a {nameof(Building)} component.");

                return null;
            }

            building.Initialize(
                data,
                originGridPosition);

            _buildingService.Register(building);

            return building;
        }
    }
}