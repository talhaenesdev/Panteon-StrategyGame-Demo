using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Models
{
    public abstract class Building : Entity, ISelectable, IDamageable
    {
        [SerializeField] protected BuildingData buildingData;

        public int CurrentHealth { get; protected set; }

        protected virtual void Awake()
        {
            CurrentHealth = buildingData.MaxHealth;
        }

        public virtual void Select()
        {
        }

        public virtual void Deselect()
        {
        }

        public virtual void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                DestroyBuilding();
            }
        }

        protected virtual void DestroyBuilding()
        {
            Destroy(gameObject);
        }
    }
}