using UnityEngine;

namespace PanteonStrategyGame.Buildings.Models
{
    public class PowerPlant : Building
    {
        public override string DisplayName => buildingData.DisplayName;
        public override Sprite Icon => buildingData.Icon;
    }
}