using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;

namespace PanteonStrategyGame.Common.Entities
{
    public abstract class Entity : MonoBehaviour, IEntity, ISelectable
    {
        public virtual string DisplayName => name;

        public virtual string EntityType => "Entity";
        [SerializeField]
        private string id;

        [SerializeField]
        private Team team;

        public string Id => id;
        public Team Team => team;
        public Transform Transform => transform;

        public int CurrentHealth { get; protected set; }

        public virtual void Select() { }

        public virtual void Deselect() { }

        public virtual void TakeDamage(int damage) { }
        protected virtual void DestroyEntity()
        {
            Destroy(gameObject);
        }

    }
}
