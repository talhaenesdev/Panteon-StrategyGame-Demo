using PanteonStrategyGame.Buildings.Models;
using UnityEngine;

namespace Assets.Scripts.Buildings.Models
{
    internal class EnemyGeneralBuilding : Building
    {
        public virtual bool IsControllable => false;
        public override string DisplayName => buildingData.DisplayName;
        public override Sprite Icon => buildingData.Icon;
    }
}
