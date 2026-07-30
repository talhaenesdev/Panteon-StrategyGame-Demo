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
                MoveSelectedUnit();
            }
        }

        private void MoveSelectedUnit()
        {
            if (_selectionService.SelectedEntity is not Unit unit)
                return;


            Vector3 target = _camera.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;

            var path = _pathfindingService.FindPath(
                unit.transform.position,
                target);

            unit.Movement.SetPath(path);

        }
    }
}