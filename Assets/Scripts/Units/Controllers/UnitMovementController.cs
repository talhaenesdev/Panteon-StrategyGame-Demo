using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Interfaces;
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
            if (_selectionService.SelectedEntity is not Unit unit)
                return;

            Vector3 mouseWorld =
                _camera.ScreenToWorldPoint(Input.mousePosition);

            mouseWorld.z = 0;

            RaycastHit2D hit =
                Physics2D.Raycast(mouseWorld, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log($"Hit : {hit.collider.name}");

                Entity entity =
                    hit.collider.GetComponentInParent<Entity>();

                Debug.Log($"Entity : {entity}");

                if (entity != null)
                {
                    if (entity == unit)
                        return;

                    if (entity.Team == unit.Team)
                        return;

                    IDamageable damageable =
                        hit.collider.GetComponentInParent<IDamageable>();
                    Debug.Log(damageable);

                    if (damageable != null)
                    {
                        Debug.Log($"Target = {entity.name}");
                        unit.Attack.SetTarget(damageable);

                        var attackPath =
                            _pathfindingService.FindPath(
                                unit.transform.position,
                                entity.transform.position);

                        Debug.Log($"Path Count = {attackPath.Count}");

                        unit.Movement.SetPath(attackPath);

                        return;
                    }
                }
            }

            unit.Attack.ClearTarget();

            var movePath =
                _pathfindingService.FindPath(
                    unit.transform.position,
                    mouseWorld);

            unit.Movement.SetPath(movePath);
        }
    }
}