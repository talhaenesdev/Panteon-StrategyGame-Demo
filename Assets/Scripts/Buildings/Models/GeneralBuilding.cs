using PanteonStrategyGame.Buildings.Models;
using UnityEngine;

namespace Assets.Scripts.Buildings.Models
{
    internal class GeneralBuilding : Building
    {
        public override string DisplayName => buildingData.DisplayName;
        public override Sprite Icon => buildingData.Icon;
    }
}
