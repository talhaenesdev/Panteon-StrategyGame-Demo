using PanteonStrategyGame.Buildings.Data;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Placement.Rules
{
    public interface IPlacementRule
    {
        bool Validate(BuildingData data, Vector2Int origin);
    }
}