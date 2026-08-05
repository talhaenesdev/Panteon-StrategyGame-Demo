using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Common.Entities
{
    public abstract class Entity : MonoBehaviour, IEntity, ISelectable
    {
        [Inject] protected SignalBus SignalBus;
        public abstract EntityType EntityType { get; }

        public abstract string DisplayName { get; }

        public abstract Sprite Icon { get; }

        [SerializeField]
        private string id;

        [SerializeField]
        private Team _team;

        public string Id => id;

        public Team Team => _team;

        public Transform Transform => transform;
        public virtual bool IsControllable => true;
        public Vector2Int OriginGridPosition { get; private set; }

        protected virtual void OnTeamChanged()
        {
        }

        public void SetTeam(Team team)
        {
            _team = team;

            OnTeamChanged();
        }

        public virtual void Initialize(
            BuildingData data,
            Vector2Int originGridPosition)
        {
            OriginGridPosition = originGridPosition;

            gameObject.SetActive(true);
        }

        public virtual void Select()
        {
        }

        public virtual void Deselect()
        {
        }

        protected virtual void DestroyEntity()
        {
            SignalBus.Fire(new EntityDestroyedSignal(this));

            SignalBus.Fire(new EntitySelectedSignal(null));

            Destroy(gameObject);
        }
    }
}