using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Pooling;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Common.Entities
{
    public abstract class Entity : MonoBehaviour, IEntity, ISelectable, IDamageable
    {
        [Inject]
        private PoolManager _poolManager;

        [Inject]
        private ISelectionService _selectionService;
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

        public int CurrentHealth { get; protected set; }

        public virtual void Select() { }

        public virtual void Deselect() { }

        public virtual void TakeDamage(int damage) { }
        protected virtual void DestroyEntity()
        {
            if (_selectionService.SelectedEntity == this)
            {
                _selectionService.ClearSelection();
            }

            _poolManager.Release(gameObject);
        }

    }
}
