using PanteonStrategyGame.Units.Models;
using UnityEngine;

namespace Assets.Scripts.Units.Models
{
    internal class EnemySoldier : Unit
    {
        public override bool IsControllable => false;
        public override string DisplayName => Data.DisplayName;
        public override Sprite Icon => Data.Icon;
    }
}
