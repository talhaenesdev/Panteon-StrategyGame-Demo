using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Buildings.Models
{
    public abstract class Building : Entity, IDamageable
    {
        #region Inject

        [Inject]
        private IAttackPositionProvider _attackPositionProvider;

        #endregion

        #region Inspector

        [Header("Building")]

        [SerializeField]
        protected BuildingData buildingData;

        [Header("Selection")]

        [SerializeField]
        private GameObject _selectionCircle;

        [Header("Team Flags")]

        [SerializeField]
        private GameObject _playerFlag;

        [SerializeField]
        private GameObject _enemyFlag;

        #endregion

        #region Properties

        public override EntityType EntityType => EntityType.Building;

        public override string DisplayName => buildingData.DisplayName;

        public override Sprite Icon => buildingData.Icon;

        public BuildingData BuildingData => buildingData;

        public Vector2Int OriginGridPosition { get; private set; }

        public int CurrentHealth { get; protected set; }

        public int MaxHealth => buildingData.MaxHealth;

        #endregion

        #region Initialization

        public virtual void Initialize(
            BuildingData data,
            Vector2Int originGridPosition)
        {
            buildingData = data;

            OriginGridPosition = originGridPosition;

            CurrentHealth = data.MaxHealth;

            RefreshFlag();

            gameObject.SetActive(true);
        }

        #endregion

        #region Team

        protected override void OnTeamChanged()
        {
            RefreshFlag();
        }

        private void RefreshFlag()
        {
            if (_playerFlag != null)
                _playerFlag.SetActive(Team == Team.Player);

            if (_enemyFlag != null)
                _enemyFlag.SetActive(Team == Team.Enemy);
        }

        #endregion

        #region Combat

        public Vector3 GetAttackPosition(Vector3 attackerPosition)
        {
            return _attackPositionProvider.GetAttackPosition(
                this,
                attackerPosition);
        }

        public void TakeDamage(
            int damage,
            IEntity attacker)
        {
            CurrentHealth -= damage;

            SignalBus.Fire(
                new EntityHealthChangedSignal(this));

            if (CurrentHealth <= 0)
            {
                DestroyEntity();
            }
        }

        #endregion

        #region Selection

        public override void Select()
        {
            if (_selectionCircle != null)
                _selectionCircle.SetActive(true);
        }

        public override void Deselect()
        {
            if (_selectionCircle != null)
                _selectionCircle.SetActive(false);
        }

        #endregion
    }
}