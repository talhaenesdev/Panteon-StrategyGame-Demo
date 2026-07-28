using PanteonStrategyGame.Buildings.Models;
using UnityEngine;

namespace PanteonStrategyGame.Grid
{
    public class GridCell
    {
        public Vector2Int Position { get; }

        public bool IsOccupied { get; private set; }

        public Building OccupiedBuilding { get; private set; }

        public GridCell(Vector2Int position)
        {
            Position = position;
        }

        public void Occupy(Building building)
        {
            OccupiedBuilding = building;
            IsOccupied = true;
        }

        public void Clear()
        {
            OccupiedBuilding = null;
            IsOccupied = false;
        }
    }
}