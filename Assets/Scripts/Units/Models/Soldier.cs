using PanteonStrategyGame.Units.Components;
using UnityEngine;

namespace PanteonStrategyGame.Units.Models
{
    public class Soldier : Unit
    {
        private UnitMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<UnitMovement>();
        }

        public UnitMovement Movement => _movement;
    }
}