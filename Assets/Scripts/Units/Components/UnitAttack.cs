using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.Units.Components
{
    public class UnitAttack : MonoBehaviour
    {
        [SerializeField]
        private MonoBehaviour testTarget;

        private UnitData _unitData;

        private IDamageable _target;

        private Transform _targetTransform;

        private float _attackTimer;

        public bool HasTarget => _target != null;

        private void OnEnable()
        {
            if (testTarget is IDamageable damageable)
            {
                SetTarget(damageable);
            }
        }
        public void Initialize(UnitData unitData)
        {
            _unitData = unitData;
        }

        public void SetTarget(IDamageable target)
        {
            Debug.Log("Target Set");
            _target = target;

            if (target is Component component)
            {
                _targetTransform = component.transform;
            }
            else
            {
                _targetTransform = null;
            }
        }

        public void ClearTarget()
        {
            _target = null;
            _targetTransform = null;
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

            _target.TakeDamage(_unitData.Damage);
        }
    }
}