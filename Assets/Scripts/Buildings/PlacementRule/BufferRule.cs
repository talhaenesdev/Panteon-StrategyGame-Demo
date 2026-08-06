using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Grid;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Placement.Rules
{
    public class BufferRule : IPlacementRule
    {
        private readonly GridManager _gridManager;

        public BufferRule(GridManager gridManager)
        {
            _gridManager = gridManager;
        }

        public bool Validate(
            BuildingData buildingData,
            Vector2Int origin)
        {
            int buffer =
                Mathf.Max(1, buildingData.BuildingBuffer);

            int minX = -buffer;
            int minY = -buffer;

            int maxX =
                buildingData.Size.x - 1 + buffer;

            int maxY =
                buildingData.Size.y - 1 + buffer;

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if (IsInsideBuildingArea(
                        x,
                        y,
                        buildingData.Size))
                    {
                        continue;
                    }

                    Vector2Int position =
                        origin + new Vector2Int(x, y);

                    if (!_gridManager.IsInsideGrid(position))
                        continue;

                    GridCell cell =
                        _gridManager.GetCell(position);

                    if (!cell.IsOccupied)
                        continue;

                    Building neighbour =
                        cell.OccupiedBuilding;

                    if (neighbour == null)
                        continue;

                    if (HasBufferConflict(
                        buildingData,
                        neighbour.BuildingData))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsInsideBuildingArea(
            int x,
            int y,
            Vector2Int size)
        {
            return x >= 0 &&
                   x < size.x &&
                   y >= 0 &&
                   y < size.y;
        }

        private static bool HasBufferConflict(
            BuildingData first,
            BuildingData second)
        {
            return first.BuildingBuffer > 0 ||
                   second.BuildingBuffer > 0;
        }
    }
}