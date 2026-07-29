using UnityEngine;
using PanteonStrategyGame.Core.Interfaces;

namespace PanteonStrategyGame.Units.Controllers
{
    public class UnitSelectionController : MonoBehaviour
    {
        private Camera _camera;
        private ISelectable _selected;

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
                Debug.Log("Nothing hit");
                return;
            }

            Debug.Log($"Hit : {hit.name}");

            var selectable = hit.GetComponent<ISelectable>();

            if (selectable == null)
            {
                Debug.Log("Object is not selectable.");
                return;
            }

            _selected?.Deselect();

            _selected = selectable;

            _selected.Select();
        }
    }
}