using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Buildings.Views;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Grid;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Buildings.Controllers
{
    public class BuildingPlacementController : MonoBehaviour
    {
        [Inject] private GridManager _gridManager;
        [Inject] private IBuildingFactory _buildingFactory;
        [Inject] private IBuildingPlacementService _validator;

        private BuildingData _selectedBuilding;
        private GhostBuilding _ghostBuilding;

        private bool _isPlacing;

        public void StartPlacement(BuildingData buildingData)
        {
            _selectedBuilding = buildingData;

            _ghostBuilding = Instantiate(buildingData.Prefab)
                .GetComponent<GhostBuilding>();

            _isPlacing = true;
        }

        private void Update()
        {
            if (!_isPlacing)
                return;

            UpdateGhost();

            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
        }

        private void UpdateGhost()
        {
            Vector3 mouseWorld =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mouseWorld.z = 0;

            Vector2Int gridPosition =
                _gridManager.GetGridPosition(mouseWorld);

            Vector3 worldPosition =
                _gridManager.GetWorldPosition(gridPosition);

            _ghostBuilding.transform.position = worldPosition;

            bool canPlace =
                _validator.CanPlace(_selectedBuilding, gridPosition);

            _ghostBuilding.SetValid(canPlace);
        }

        private void PlaceBuilding()
        {
            Vector3 mouseWorld =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mouseWorld.z = 0;

            Vector2Int gridPosition =
                _gridManager.GetGridPosition(mouseWorld);

            if (!_validator.CanPlace(_selectedBuilding, gridPosition))
                return;

            Building building =
                _buildingFactory.Create(
                    _selectedBuilding,
                    _gridManager.GetWorldPosition(gridPosition));

            _gridManager.PlaceBuilding(
                building,
                _selectedBuilding,
                gridPosition);

            Destroy(_ghostBuilding.gameObject);

            _ghostBuilding = null;

            _selectedBuilding = null;

            _isPlacing = false;
        }
    }
}