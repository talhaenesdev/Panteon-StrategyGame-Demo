using System.Collections.Generic;
using UnityEngine;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IPathfindingService
    {
        List<Vector2Int> FindPath(
            Vector2Int start,
            Vector2Int end);
    }
}