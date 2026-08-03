using PanteonStrategyGame.Buildings.Models;
using UnityEngine;

namespace PanteonStrategyGame.Grid
{
    public class GridCell
    {
        public Vector2Int Position { get; }

        public bool IsOccupied { get; private set; }

        public Building OccupiedBuilding { get; private set; }

        public Building Building { get; private set; }

        public void Occupy(Building building)
        {
            Building = building;
            IsOccupied = true;
        }

        public GridCell(Vector2Int position)
        {
            Position = position;
        }

        public void Clear()
        {
            OccupiedBuilding = null;
            Building = null;
            IsOccupied = false;
        }
    }
}