using PanteonStrategyGame.Combat.Interfaces;
using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Utilities;
using PanteonStrategyGame.Units.Models;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Units.Controllers
{
    public class UnitMovementController : MonoBehaviour
    {
        [Inject] private ISelectionService _selectionService;
        [Inject] private IPathfindingService _pathfindingService;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RightClick();
            }
        }

        private void RightClick()
        {
            Unit unit = GetSelectedUnit();

            if (unit == null)
                return;

            if (!unit.IsControllable)
                return;

            Vector3 mouseWorld =
                MouseUtility.GetMouseWorldPosition(_camera);

            Entity clickedEntity =
                GetClickedEntity(mouseWorld);


            if (CanAttack(unit, clickedEntity))
            {
                StartAttack(
                    unit,
                    (IDamageable)clickedEntity);

                return;
            }

            MoveToPosition(
                unit,
                mouseWorld);
        }

        private Unit GetSelectedUnit()
        {
            Unit unit =
                _selectionService.SelectedEntity as Unit;

            if (unit == null)
                return null;

            if (!unit.IsControllable)
                return null;

            return unit;
        }

        private Entity GetClickedEntity(Vector3 mouseWorld)
        {
            RaycastHit2D hit =
                Physics2D.Raycast(
                    mouseWorld,
                    Vector2.zero);

            if (hit.collider == null)
                return null;

            return hit.collider.GetComponentInParent<Entity>();
        }

        private bool CanAttack(Unit attacker,Entity target)
        {
            if (target == null)
                return false;

            if (target == attacker)
                return false;

            if (target.Team == attacker.Team)
                return false;

            return target is IDamageable;
        }

        private void StartAttack(Unit attacker,IDamageable target)
        {
            attacker.Attack.SetTarget(target);

            MoveUnit(
                attacker,
                ((Component)target).transform.position);
        }

        private void MoveToPosition(Unit unit,Vector3 destination)
        {
            unit.Attack.ClearTarget();

            MoveUnit(unit, destination);
        }

        private void MoveUnit(Unit unit,Vector3 destination)
        {
            var path =
                _pathfindingService.FindPath(
                    unit.transform.position,
                    destination);

            unit.Movement.SetPath(path);
        }
    }
}