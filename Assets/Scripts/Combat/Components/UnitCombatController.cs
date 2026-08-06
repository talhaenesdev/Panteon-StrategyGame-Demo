using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Models;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Combat.Components
{
    [RequireComponent(typeof(Unit))]
    public class UnitCombatController : MonoBehaviour
    {
        [Inject]
        private IPathfindingService _pathfindingService;

        [SerializeField]
        private float _repathInterval = 0.25f;

        private Unit _unit;
        private float _repathTimer;

        private void Awake()
        {
            _unit = GetComponent<Unit>();
        }

        private void Update()
        {
            if (_unit == null)
                return;

            if (!_unit.Attack.HasTarget)
            {
                _repathTimer = 0f;
                return;
            }

            Transform target =
                _unit.Attack.TargetTransform;

            if (target == null)
            {
                _unit.Attack.ClearTarget();
                _repathTimer = 0f;
                return;
            }

            if (_unit.Attack.IsTargetInRange())
            {
                _unit.Movement.Stop();
                _repathTimer = 0f;
                return;
            }

            _repathTimer += Time.deltaTime;

            if (_repathTimer < _repathInterval)
                return;

            _repathTimer = 0f;

            var path =
                _pathfindingService.FindPath(
                    transform.position,
                    target.position);

            if (path != null)
            {
                _unit.Movement.SetPath(path);
            }
        }
    }
}