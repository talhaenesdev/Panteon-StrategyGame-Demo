using PanteonStrategyGame.Combat.Interfaces;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Data;
using PanteonStrategyGame.Units.Models;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Units.Components
{
    public class UnitAttack : MonoBehaviour
    {
        [SerializeField]
        private Collider2D _collider;

        [SerializeField]
        private UnitMovement _movement;

        [SerializeField]
        private Unit _owner;

        [Inject]
        private IPathfindingService _pathfindingService;

        private UnitData _unitData;

        private IDamageable _target;

        private float _attackTimer;
        private float _pathRefreshTimer;

        private const float PathRefreshInterval = 0.25f;
        private Transform _targetTransform;

        public Transform TargetTransform => _targetTransform;
        public bool HasTarget => _target != null;

        public void Initialize(UnitData unitData)
        {
            _unitData = unitData;
        }

        public void SetTarget(IDamageable target)
        {
            _target = target;
            _attackTimer = 0f;
            _pathRefreshTimer = 0f;
        }

        public void ClearTarget()
        {
            _target = null;

            _attackTimer = 0f;
            _pathRefreshTimer = 0f;

            _movement.Stop();
        }

        public bool IsTargetInRange()
        {
            if (_target == null)
                return false;

            Component targetComponent = _target as Component;

            if (targetComponent == null)
                return false;

            Collider2D targetCollider =
                targetComponent.GetComponent<Collider2D>();

            if (targetCollider == null)
                return false;

            ColliderDistance2D distance =
                Physics2D.Distance(
                    _collider,
                    targetCollider);

            return distance.distance <= _unitData.AttackRange;
        }

        private void Update()
        {
            if (_target == null)
                return;

            Component targetComponent =
                _target as Component;

            if (targetComponent == null)
            {
                ClearTarget();
                return;
            }

            if (_target.CurrentHealth <= 0)
            {
                ClearTarget();
                return;
            }

            if (!IsTargetInRange())
            {
                _pathRefreshTimer += Time.deltaTime;

                if (_pathRefreshTimer >= PathRefreshInterval)
                {
                    _pathRefreshTimer = 0f;

                    Vector3 attackPoint =
                        _target.GetAttackPosition(
                            transform.position);

                    var path =
                        _pathfindingService.FindPath(
                            transform.position,
                            attackPoint);

                    if (path != null)
                    {
                        _movement.SetPath(path);
                    }
                }

                return;
            }

            _movement.Stop();

            _attackTimer += Time.deltaTime;

            if (_attackTimer < _unitData.AttackRate)
                return;

            _attackTimer = 0f;

            _target.TakeDamage(
                _unitData.Damage,
                _owner);
        }
    }
}