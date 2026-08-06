using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;

namespace PanteonStrategyGame.Core.Services
{
    public class RuntimeHierarchyService :
        MonoBehaviour,
        IRuntimeHierarchyService
    {
        [SerializeField]
        private Transform _runtimePlayerUnits;

        [SerializeField]
        private Transform _runtimePlayerBuildings;

        public Transform RuntimeUnits => _runtimePlayerUnits;
        public Transform RuntimeBuildings => _runtimePlayerBuildings;

    }
}