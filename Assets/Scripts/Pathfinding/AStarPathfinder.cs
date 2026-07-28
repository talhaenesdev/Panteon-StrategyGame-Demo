using PanteonStrategyGame.Core.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonStrategyGame.Pathfinding
{
    public class AStarPathfinder : IPathfindingService
    {
        public List<Vector2Int> FindPath(
            Vector2Int start,
            Vector2Int end)
        {
            return new List<Vector2Int>();
        }
    }
}