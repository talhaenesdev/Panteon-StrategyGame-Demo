using UnityEngine;
using PanteonStrategyGame.Buildings.Data;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IBuildingPlacementService
    {
        bool CanPlace(BuildingData buildingData, Vector2Int gridPosition);
    }
}