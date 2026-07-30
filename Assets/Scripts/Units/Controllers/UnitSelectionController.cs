using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Models;
using UnityEngine;
using Zenject;

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

            Entity entity = hit.GetComponent<Entity>();

            if (entity == null)
            {
                Debug.Log("Hit object is not an Entity.");
                return;
            }

            _selectionService.Select(entity);
        }
    }
}