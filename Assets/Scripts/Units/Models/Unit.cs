using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Components;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.Units.Models
{
    public abstract class Unit : Entity, ISelectable
    {
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
        }
        public virtual void Select()
        {
            selectionCircle.SetActive(true);
        }

        public virtual void Deselect()
        {
            selectionCircle.SetActive(false);
        }
    }
}