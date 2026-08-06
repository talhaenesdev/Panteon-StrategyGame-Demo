using UnityEngine;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IRuntimeHierarchyService
    {
        Transform RuntimeUnits { get; }
        Transform RuntimeBuildings { get; }
    }
}