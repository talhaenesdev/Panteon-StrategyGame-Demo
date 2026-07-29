using System.Collections.Generic;
using UnityEngine;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IPathfindingService
    {
        List<Vector3> FindPath(
            Vector3 start,
            Vector3 target);
    }
}