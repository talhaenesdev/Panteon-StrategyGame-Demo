using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Units.Data;
using PanteonStrategyGame.Units.Models;
using UnityEngine;

namespace PanteonStrategyGame.Common.Interfaces
{
    public interface IEntitySpawnService
    {
        Unit SpawnUnit(
            string poolKey,
            UnitData data,
            Vector2Int gridPosition,
            Team team);

        Building SpawnBuilding(
            string poolKey,
            BuildingData data,
            Vector2Int gridPosition,
            Team team);
    }
}