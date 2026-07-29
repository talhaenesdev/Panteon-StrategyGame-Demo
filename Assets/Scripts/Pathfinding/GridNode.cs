using UnityEngine;

namespace PanteonStrategyGame.Pathfinding
{
    public class GridNode
    {
        public Vector2Int GridPosition { get; }
        public Vector3 WorldPosition { get; }

        public bool Walkable { get; set; }

        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost => GCost + HCost;

        public GridNode Parent { get; set; }

        public GridNode(Vector2Int gridPosition, Vector3 worldPosition, bool walkable)
        {
            GridPosition = gridPosition;
            WorldPosition = worldPosition;
            Walkable = walkable;
        }

        public void ResetPathData()
        {
            GCost = int.MaxValue;
            HCost = 0;
            Parent = null;
        }
    }
}