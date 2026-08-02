using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Units.Components;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.Units.Models
{
    public abstract class Unit : Entity
    {
        public override EntityType EntityType => EntityType.Unit;
        protected UnitData Data;

        public int Damage => Data.Damage;

        public float MoveSpeed => Data.MoveSpeed;

        [SerializeField]
        private GameObject selectionCircle;

        [SerializeField]
        private UnitMovement _movement;
        public UnitMovement Movement => _movement;

        public virtual void Initialize(UnitData data)
        {
            Data = data;
            CurrentHealth = data.MaxHealth;
            _movement.Initialize(MoveSpeed);
        }
        public override void Select()
        {
            selectionCircle.SetActive(true);
        }

        public override void Deselect()
        {
            selectionCircle.SetActive(false);
        }
        public override void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                DestroyEntity();
            }
        }
    }
}