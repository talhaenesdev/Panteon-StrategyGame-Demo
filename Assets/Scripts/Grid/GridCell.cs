using PanteonStrategyGame.Buildings.Models;
using UnityEngine;

namespace PanteonStrategyGame.Grid
{
    public class GridCell
    {
        public Vector2Int Position { get; }

        public Building OccupiedBuilding { get; private set; }

        public bool IsOccupied => OccupiedBuilding != null;

        public GridCell(Vector2Int position)
        {
            Position = position;
        }

        public void Occupy(Building building)
        {
            OccupiedBuilding = building;
        }

        public void Clear()
        {
            OccupiedBuilding = null;
        }
    }
}