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
        private UnitMovement _movement;

        [SerializeField]
        private Unit _owner;

        [Inject]
        private IPathfindingService _pathfindingService;

        private UnitData _unitData;

        private IDamageable _target;
        private Transform _targetTransform;

        private float _attackTimer;

        public bool HasTarget => _target != null;

        public Transform TargetTransform => _targetTransform;

        public void Initialize(UnitData unitData)
        {
            _unitData = unitData;
        }

        public void SetTarget(IDamageable target)
        {
            Debug.Log("SetTarget");
            _target = target;

            if (target is Component component)
            {
                _targetTransform = component.transform;
            }

            _attackTimer = 0f;
        }

        public void ClearTarget()
        {
            Debug.Log("ClearTarget");
            _target = null;
            _targetTransform = null;
            _attackTimer = 0f;

            _movement.Stop();
        }

        public bool IsTargetInRange()
        {
            if (_target == null)
                return false;

            Vector3 attackPosition =
                _target.GetAttackPosition(transform.position);

            float distance = Vector3.Distance(
                transform.position,
                attackPosition);

            return distance <= _unitData.AttackRange;
        }

        private void Update()
        {
            if (_target == null)
                return;

            if (_target.CurrentHealth <= 0)
            {
                ClearTarget();
                return;
            }

            if (!IsTargetInRange())
            {
                if (!_movement.HasPath)
                {
                    Vector3 attackPosition =
                        _target.GetAttackPosition(transform.position);

                    var path =
                        _pathfindingService.FindPath(
                            transform.position,
                            attackPosition);

                    _movement.SetPath(path);
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