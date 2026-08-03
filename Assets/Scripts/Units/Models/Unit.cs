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
        public float AttackRange => Data.AttackRange;
        public float AttackRate => Data.AttackRate;

        [SerializeField]
        private GameObject selectionCircle;

        [SerializeField]
        private UnitMovement _movement;
        public UnitMovement Movement => _movement;

        [SerializeField]
        private UnitAttack _attack;
        public UnitAttack Attack => _attack;

        public virtual void Initialize(UnitData data)
        {
            Data = data;

            CurrentHealth = data.MaxHealth;

            _movement.Initialize(data.MoveSpeed);

            _attack.Initialize(data);
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
            UnityEngine.Debug.Log("TakeDamage " + damage);
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                DestroyEntity();
            }
        }
    }
}