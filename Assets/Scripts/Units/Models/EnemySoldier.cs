using UnityEngine;

namespace PanteonStrategyGame.Units.Models
{
    internal class EnemySoldier : Unit
    {
        public override bool IsControllable => false;
        public override string DisplayName => _data.DisplayName;
        public override Sprite Icon => _data.Icon;
    }
}
