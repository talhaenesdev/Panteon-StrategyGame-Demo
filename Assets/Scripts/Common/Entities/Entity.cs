using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Common.Entities
{
    public abstract class Entity : MonoBehaviour, IEntity, ISelectable
    {
        [Inject]
        protected SignalBus SignalBus;
        public abstract EntityType EntityType { get; }

        public abstract string DisplayName { get; }

        public abstract Sprite Icon { get; }

        [SerializeField]
        private string id;

        [SerializeField]
        private Team team;

        public string Id => id;

        public Team Team => team;

        public Transform Transform => transform;

        public virtual void Select()
        {
        }

        public virtual void Deselect()
        {
        }

        protected virtual void DestroyEntity()
        {
            Destroy(gameObject);
        }
    }
}