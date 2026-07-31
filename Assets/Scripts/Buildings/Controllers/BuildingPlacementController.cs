using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Buildings.Views;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Signals;
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
        [Inject] private SignalBus _signalBus;

        private BuildingData _selectedBuilding;
        private GhostBuilding _ghostBuilding;

        private bool _isPlacing;

        private void OnEnable()
        {
            _signalBus.Subscribe<BuildingPlacementRequestedSignal>(OnPlacementRequested);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<BuildingPlacementRequestedSignal>(OnPlacementRequested);
        }

        private void OnPlacementRequested(BuildingPlacementRequestedSignal signal)
        {
            StartPlacement(signal.BuildingData);
        }

        public void StartPlacement(BuildingData buildingData)
        {
            if (_ghostBuilding != null)
                Destroy(_ghostBuilding.gameObject);

            _selectedBuilding = buildingData;

            _ghostBuilding = Instantiate(
                buildingData.GhostPrefab,
                Vector3.zero,
                Quaternion.identity)
                .GetComponent<GhostBuilding>();

            _isPlacing = true;
        }

        private void Update()
        {
            if (!_isPlacing)
                return;

            UpdateGhost();

            if (Input.GetMouseButtonDown(0))
                PlaceBuilding();

            if (Input.GetMouseButtonDown(1))
                CancelPlacement();
        }

        private void UpdateGhost()
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;

            Vector2Int gridPos = _gridManager.GetGridPosition(mouseWorld);

            _ghostBuilding.transform.position =
                _gridManager.GetWorldPosition(gridPos);

            _ghostBuilding.SetValid(
                _validator.CanPlace(_selectedBuilding, gridPos));
        }

        private void PlaceBuilding()
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;

            Vector2Int gridPos =
                _gridManager.GetGridPosition(mouseWorld);

            if (!_validator.CanPlace(_selectedBuilding, gridPos))
                return;

            Building building = _buildingFactory.Create(
                _selectedBuilding,
                _gridManager.GetWorldPosition(gridPos));

            _gridManager.PlaceBuilding(
                building,
                _selectedBuilding,
                gridPos);

            CancelPlacement();
        }

        private void CancelPlacement()
        {
            if (_ghostBuilding != null)
                Destroy(_ghostBuilding.gameObject);

            _ghostBuilding = null;
            _selectedBuilding = null;
            _isPlacing = false;
        }
    }
}