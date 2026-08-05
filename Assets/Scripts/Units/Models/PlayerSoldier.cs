
using UnityEngine;

namespace PanteonStrategyGame.Units.Models
{
    public class PlayerSoldier : Unit
    {
        public override bool IsControllable => true;
        public override string DisplayName => Data.DisplayName;
        public override Sprite Icon => Data.Icon;
    }
}