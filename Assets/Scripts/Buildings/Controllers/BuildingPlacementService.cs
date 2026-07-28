using UnityEngine;
using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Grid;

namespace PanteonStrategyGame.Buildings.Controllers
{
    public class BuildingPlacementService : IBuildingPlacementService
    {
        private readonly GridManager _gridManager;

        public BuildingPlacementService(GridManager gridManager)
        {
            _gridManager = gridManager;
        }

        public bool CanPlace(BuildingData buildingData, Vector2Int gridPosition)
        {
            return _gridManager.CanPlaceBuilding(buildingData, gridPosition);
        }
    }
}