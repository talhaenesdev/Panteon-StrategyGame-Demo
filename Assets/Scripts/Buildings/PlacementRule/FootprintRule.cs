using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Grid;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Placement.Rules
{
    public class FootprintRule : IPlacementRule
    {
        private readonly GridManager _grid;

        public FootprintRule(GridManager grid)
        {
            _grid = grid;
        }

        public bool Validate(BuildingData data, Vector2Int origin)
        {
            for (int x = 0; x < data.Size.x; x++)
            {
                for (int y = 0; y < data.Size.y; y++)
                {
                    Vector2Int pos = origin + new Vector2Int(x, y);

                    if (!_grid.IsInsideGrid(pos))
                        return false;

                    if (_grid.GetCell(pos).IsOccupied)
                        return false;
                }
            }

            return true;
        }
    }
}