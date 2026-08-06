using UnityEngine;

namespace PanteonStrategyGame.Buildings.Models
{
    public class EnemyBarracks : Building
    {
        public override string DisplayName => BuildingData.DisplayName;

        public override Sprite Icon => BuildingData.Icon;

    }
}