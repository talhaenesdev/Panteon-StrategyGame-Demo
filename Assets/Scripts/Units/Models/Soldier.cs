using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Units.Components;
using UnityEngine;

namespace PanteonStrategyGame.Units.Models
{
    public class Soldier : Unit
    {
        public override string DisplayName => Data.DisplayName;
        public override Sprite Icon => Data.Icon;
        private UnitMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<UnitMovement>();
        }

        public UnitMovement Movement => _movement;
    }
}