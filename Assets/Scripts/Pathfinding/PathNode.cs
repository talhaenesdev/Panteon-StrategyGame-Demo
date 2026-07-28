using UnityEngine;

namespace PanteonStrategyGame.Pathfinding
{
    public class PathNode
    {
        public Vector2Int Position { get; }

        public bool Walkable { get; set; }

        public int GCost { get; set; }

        public int HCost { get; set; }

        public int FCost => GCost + HCost;

        public PathNode Parent { get; set; }

        public PathNode(Vector2Int position)
        {
            Position = position;
            Walkable = true;
        }
    }
}