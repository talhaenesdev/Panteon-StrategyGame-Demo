using PanteonStrategyGame.Common.Entities;
using UnityEngine;

namespace PanteonStrategyGame.Enemies.Interfaces
{
    public interface IEnemyTargetFinder
    {
        Entity FindNearestTarget(Vector3 position);
    }
}