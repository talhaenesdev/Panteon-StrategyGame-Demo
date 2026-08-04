using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Grid;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Placement.Rules
{
    public class BufferRule : IPlacementRule
    {
        private readonly GridManager _grid;

        public BufferRule(GridManager grid)
        {
            _grid = grid;
        }

        public bool Validate(BuildingData data, Vector2Int origin)
        {
            int ownBuffer = data.BuildingBuffer;

            int radius = Mathf.Max(1, ownBuffer);

            int minX = -radius;
            int minY = -radius;

            int maxX = data.Size.x - 1 + radius;
            int maxY = data.Size.y - 1 + radius;

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if (x >= 0 &&
                        x < data.Size.x &&
                        y >= 0 &&
                        y < data.Size.y)
                        continue;

                    Vector2Int pos = origin + new Vector2Int(x, y);

                    if (!_grid.IsInsideGrid(pos))
                        continue;

                    GridCell cell = _grid.GetCell(pos);

                    if (!cell.IsOccupied)
                        continue;

                    Building other = cell.OccupiedBuilding;

                    if (ownBuffer > 0 ||
                        other.BuildingData.BuildingBuffer > 0)
                        return false;
                }
            }

            return true;
        }
    }
}