using UnityEngine;
using Zenject;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Models;

namespace PanteonStrategyGame.Units.Controllers
{
    public class UnitSelectionController : MonoBehaviour
    {
        [Inject] private ISelectionService _selectionService;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectUnit();
            }
        }

        private void SelectUnit()
        {
            Vector2 worldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapPoint(worldPoint);


            if (hit == null)
            {
                _selectionService.ClearSelection();
                return;
            }

            Unit unit = hit.GetComponent<Unit>();

            if (unit == null)
            {
                _selectionService.ClearSelection();
                return;
            }

            _selectionService.Select(unit);
        }
    }
}