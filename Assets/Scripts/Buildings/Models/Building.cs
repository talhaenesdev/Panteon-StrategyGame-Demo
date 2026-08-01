using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Models
{
    public abstract class Building : Entity, IDamageable
    {
        public override EntityType EntityType => EntityType.Building;

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

        public override void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

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
            selectionCircle.SetActive(false);
        }
    }
}