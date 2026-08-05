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
        [Inject]
        private IAttackPositionProvider _attackPositionProvider;

        public override EntityType EntityType => EntityType.Building;

        [SerializeField]
        protected BuildingData buildingData;

        [SerializeField]
        private GameObject selectionCircle;

        public BuildingData BuildingData => buildingData;

        public Vector2Int OriginGridPosition { get; private set; }

        public int CurrentHealth { get; protected set; }

        public int MaxHealth => buildingData.MaxHealth;

        public override string DisplayName => buildingData.DisplayName;

        public override Sprite Icon => buildingData.Icon;
        [SerializeField]
        private GameObject playerFlag;

        [SerializeField]
        private GameObject enemyFlag;

        protected override void OnTeamChanged()
        {
            RefreshFlag();
        }
        private void RefreshFlag()
        {
            var currentTeam = Team;

            if (playerFlag != null)
                playerFlag.SetActive(currentTeam == PanteonStrategyGame.Common.Enums.Team.Player);

            if (enemyFlag != null)
                enemyFlag.SetActive(currentTeam == PanteonStrategyGame.Common.Enums.Team.Enemy);
        }
        public virtual void Initialize(
            BuildingData data,
            Vector2Int originGridPosition)
        {
            buildingData = data;

            OriginGridPosition = originGridPosition;

            CurrentHealth = data.MaxHealth;

            gameObject.SetActive(true);
        }

        public Vector3 GetAttackPosition(Vector3 attackerPosition)
        {
            return _attackPositionProvider.GetAttackPosition(
                this,
                attackerPosition);
        }

        public void TakeDamage(int damage, IEntity attacker)
        {
            CurrentHealth -= damage;

            SignalBus.Fire(new EntityHealthChangedSignal(this));

            if (CurrentHealth <= 0)
            {
                DestroyEntity();
            }
        }

        public override void Select()
        {
            if (selectionCircle != null)
                selectionCircle.SetActive(true);
        }

        public override void Deselect()
        {
            if (selectionCircle != null)
                selectionCircle.SetActive(false);
        }
    }
}