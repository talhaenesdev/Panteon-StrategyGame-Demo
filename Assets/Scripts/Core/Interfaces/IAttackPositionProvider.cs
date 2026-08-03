using UnityEngine;
using PanteonStrategyGame.Buildings.Models;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IAttackPositionProvider
    {
        Vector3 GetAttackPosition(
            Building building,
            Vector3 attackerPosition);
    }
}