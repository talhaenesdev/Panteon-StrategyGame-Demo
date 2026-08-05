using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.Units.Components;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.Units.Models
{
    public abstract class Unit : Entity, IDamageable
    {
        [SerializeField]
        private UnitTeamMaterial _teamMaterial;
        public override EntityType EntityType => EntityType.Unit;

        protected UnitData Data;
        public int CurrentHealth { get; protected set; }

        public int MaxHealth => Data.MaxHealth;

        [SerializeField]
        private GameObject selectionCircle;

        [SerializeField]
        private UnitMovement _movement;
        public UnitMovement Movement => _movement;

        [SerializeField]
        private UnitAttack _attack;
        public UnitAttack Attack => _attack;

        public Vector3 GetAttackPosition(Vector3 attackerPosition)
        {
            return transform.position;
        }

        public virtual void Initialize(UnitData data)
        {
            Data = data;

            CurrentHealth = data.MaxHealth;

            _movement.Initialize(data.MoveSpeed);


            Attack.Initialize(data);

            _teamMaterial.SetTeam(Team);
        }

        public override void Select()
        {
            selectionCircle.SetActive(true);
        }

        public override void Deselect()
        {
            selectionCircle.SetActive(false);
        }

        public void TakeDamage(int damage, IEntity attacker)
        {
            CurrentHealth -= damage;

            SignalBus.Fire(
                new EntityHealthChangedSignal(this));

            if (CurrentHealth <= 0)
            {
                DestroyEntity();
                return;
            }

            if (attacker is IDamageable damageable)
            {
                Attack.SetTarget(damageable);
            }
        }
    }
}