using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Data;
using PanteonStrategyGame.Units.Models;
using UnityEngine;

namespace PanteonStrategyGame.Units.Components
{
    public class UnitAttack : MonoBehaviour
    {
        [SerializeField] private Unit _owner;
        private UnitData _unitData;

        private IDamageable _target;

        private Transform _targetTransform;

        public Transform TargetTransform => _targetTransform;
        private float _attackTimer;

        public bool HasTarget => _target != null;

        public void Initialize(UnitData unitData)
        {
            _unitData = unitData;
        }

        public void SetTarget(IDamageable target)
        {
            _target = target;

            if (target is Component component)
            {
                _targetTransform = component.transform;
            }

            _attackTimer = 0f;
        }

        public void ClearTarget()
        {
            _target = null;
            _targetTransform = null;
            _attackTimer = 0f;
        }

        public bool IsTargetInRange()
        {
            if (_targetTransform == null)
                return false;

            float distance =
                Vector3.Distance(
                    transform.position,
                    _targetTransform.position);

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
                return;

            _attackTimer += Time.deltaTime;

            if (_attackTimer < _unitData.AttackRate)
                return;

            _attackTimer = 0f;

            _target.TakeDamage(_unitData.Damage, _owner);
        }
    }
}