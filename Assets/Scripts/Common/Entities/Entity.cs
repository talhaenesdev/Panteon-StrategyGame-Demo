using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Common.Interfaces;
using PanteonStrategyGame.Core.Signals;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Common.Entities
{
    public abstract class Entity : MonoBehaviour, IEntity, ISelectable
    {
        #region Inject

        [Inject]
        protected SignalBus SignalBus;

        #endregion

        #region Properties

        private Team _team;

        public abstract EntityType EntityType { get; }

        public abstract string DisplayName { get; }

        public abstract Sprite Icon { get; }

        public virtual bool IsControllable => true;

        public Team Team => _team;

        public Transform Transform => transform;

        #endregion

        #region Team

        public void SetTeam(Team team)
        {
            if (_team == team)
                return;

            _team = team;

            OnTeamChanged();
        }

        protected virtual void OnTeamChanged()
        {
        }

        #endregion

        #region Selection

        public virtual void Select()
        {
        }

        public virtual void Deselect()
        {
        }

        #endregion

        #region Lifetime

        protected virtual void DestroyEntity()
        {
            SignalBus.Fire(
                new EntityDestroyedSignal(this));

            SignalBus.Fire(
                new EntitySelectedSignal(null));

            Destroy(gameObject);
        }

        #endregion
    }
}