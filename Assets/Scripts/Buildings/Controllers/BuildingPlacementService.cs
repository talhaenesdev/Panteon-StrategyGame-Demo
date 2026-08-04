using System.Collections.Generic;
using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Placement.Rules;
using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Services
{
    public class BuildingPlacementService
        : IBuildingPlacementService
    {
        private readonly List<IPlacementRule> _rules;

        public BuildingPlacementService(
            List<IPlacementRule> rules)
        {
            _rules = rules;
        }

        public bool CanPlace(BuildingData data, Vector2Int origin)
        {
            foreach (IPlacementRule rule in _rules)
            {
                if (!rule.Validate(data, origin))
                    return false;
            }

            return true;
        }
    }
}