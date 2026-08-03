using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using PanteonStrategyGame.Units.Models;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Models
{
    public abstract class Building : Entity, IDamageable
    {
        public override EntityType EntityType => EntityType.Building; 
        public int CurrentHealth { get; protected set; }

        public int MaxHealth => buildingData.MaxHealth;
        [SerializeField]
        protected BuildingData buildingData;

        [SerializeField]
        private GameObject selectionCircle;

        public virtual void Initialize(BuildingData data)
        {
            buildingData = data;

            CurrentHealth = data.MaxHealth;

            gameObject.SetActive(true);
        }

        public void TakeDamage(int damage, IEntity attacker)
        {
            Debug.Log($"{name} took {damage} damage.");

            CurrentHealth -= damage;

            Debug.Log($"Current Health : {CurrentHealth}");

            SignalBus.Fire(new EntityHealthChangedSignal(this));

            if (CurrentHealth <= 0)
            {
                DestroyEntity();
            }
        }

        public override void Select()
        {
            selectionCircle.SetActive(true);
        }

        public override void Deselect()
        {
            if (selectionCircle != null)
            {
                selectionCircle.SetActive(false);
            }
        }
    }
}