using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Models;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Units.Components
{
    public class UnitCombatController : MonoBehaviour
    {
        [Inject] private IPathfindingService _pathfindingService;

        private Unit _unit;

        [SerializeField]
        private float repathInterval = 0.25f;

        private float _timer;

        private void Awake()
        {
            _unit = GetComponent<Unit>();
        }

        private void Update()
        {
            if (!_unit.Attack.HasTarget)
                return;

            if (_unit.Attack.IsTargetInRange())
            {
                _unit.Movement.Stop();
                return;
            }

            _timer += Time.deltaTime;

            if (_timer < repathInterval)
                return;

            _timer = 0;

            Transform target =
                _unit.Attack.TargetTransform;

            if (target == null)
                return;

            var path =
                _pathfindingService.FindPath(
                    transform.position,
                    target.position);

            _unit.Movement.SetPath(path);
        }
    }
}