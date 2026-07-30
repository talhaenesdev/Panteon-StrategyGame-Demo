using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Models
{
    public abstract class Building : Entity, IDamageable
    {
        public override string EntityType => "Building";
        [SerializeField]
        protected BuildingData buildingData;
        [SerializeField]
        private GameObject selectionCircle;

        protected virtual void Awake()
        {
            CurrentHealth = buildingData.MaxHealth;
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
            Debug.Log("Barracks Selected");

            selectionCircle.SetActive(true);
        }

        public override void Deselect()
        {
            selectionCircle.SetActive(false);
        }
    }
}