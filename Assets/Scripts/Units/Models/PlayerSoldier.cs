
using UnityEngine;

namespace PanteonStrategyGame.Units.Models
{
    public class PlayerSoldier : Unit
    {
        public override bool IsControllable => true;
        public override string DisplayName => _data.DisplayName;
        public override Sprite Icon => _data.Icon;
    }
}