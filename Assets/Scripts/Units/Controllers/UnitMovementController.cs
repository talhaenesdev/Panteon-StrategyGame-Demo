using PanteonStrategyGame.Core.Interfaces;
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

            Debug.Log($"Current Unit : {_selectionService.SelectedUnit}");

            if (_selectionService.SelectedUnit == null)
                return;


            Vector3 target = _camera.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;

            var path = _pathfindingService.FindPath(
                _selectionService.SelectedUnit.transform.position,
                target);
            Debug.Log($"Path Count : {path.Count}");
            _selectionService.SelectedUnit.Movement.SetPath(path);
        }
    }
}