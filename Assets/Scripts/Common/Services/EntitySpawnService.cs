using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Common.Interfaces;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Pooling;
using PanteonStrategyGame.Grid;
using PanteonStrategyGame.Units.Data;
using PanteonStrategyGame.Units.Models;
using UnityEngine;

namespace PanteonStrategyGame.Common.Services
{
    public class EntitySpawnService : IEntitySpawnService
    {
        private readonly PoolManager _poolManager;
        private readonly GridManager _gridManager;
        private readonly IRuntimeHierarchyService _runtimeHierarchy;

        public EntitySpawnService(
            PoolManager poolManager,
            GridManager gridManager,
            IRuntimeHierarchyService runtimeHierarchy)
        {
            _poolManager = poolManager;
            _gridManager = gridManager;
            _runtimeHierarchy = runtimeHierarchy;
        }

        public Unit SpawnUnit(
            string poolKey,
            UnitData data,
            Vector2Int gridPosition,
            Team team)
        {
            Vector3 worldPosition =
                _gridManager.GetWorldPosition(gridPosition);

            GameObject obj =
                _poolManager.Get(poolKey,_runtimeHierarchy.RuntimeUnits);

            obj.transform.SetPositionAndRotation(
                worldPosition,
                Quaternion.identity);

            Unit unit =
                obj.GetComponent<Unit>();

            unit.SetTeam(team);

            unit.Initialize(data);

            _gridManager.SetWalkable(
                gridPosition,
                false);

            return unit;
        }

        public Building SpawnBuilding(
            string poolKey,
            BuildingData data,
            Vector2Int gridPosition,
            Team team)
        {
            Vector3 worldPosition =
                _gridManager.GetBuildingCenterPosition(
                    gridPosition,
                    data.Size);

            GameObject obj =
                _poolManager.Get(poolKey,_runtimeHierarchy.RuntimeBuildings);

            obj.transform.SetPositionAndRotation(
                worldPosition,
                Quaternion.identity);

            Building building =
                obj.GetComponent<Building>();

            building.SetTeam(team);

            building.Initialize(
                data,
                gridPosition);

            _gridManager.PlaceBuilding(
                building,
                data,
                gridPosition);

            return building;
        }
    }
}