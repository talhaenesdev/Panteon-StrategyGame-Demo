using PanteonStrategyGame.Common.Entities;
using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
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
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (Input.GetMouseButtonDown(0))
            {
                SelectUnit();
            }
        }

        private void SelectUnit()
        {
            Vector2 worldPoint =
                _camera.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit =
                Physics2D.OverlapPoint(worldPoint);
            Debug.Log(hit);
            if (hit == null)
            {
                _selectionService.ClearSelection();
                return;
            }

            Entity entity =
                hit.GetComponentInParent<Entity>();
            Debug.Log(entity);
            if (entity == null)
            {
                _selectionService.ClearSelection();
                return;
            }

            _selectionService.Select(entity);
        }
    }
}