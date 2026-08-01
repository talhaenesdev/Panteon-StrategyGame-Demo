using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Buildings.Views;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Core.Pooling;
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
        [Inject] private PoolManager _poolManager;

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
            {
                _poolManager.Release(_ghostBuilding.gameObject);
                _ghostBuilding = null;
            }

            _selectedBuilding = buildingData;

            GameObject ghost =
                _poolManager.Get(buildingData.GhostPoolKey);

            ghost.transform.SetPositionAndRotation(
                Vector3.zero,
                Quaternion.identity);

            _ghostBuilding = ghost.GetComponent<GhostBuilding>();

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
            if (_ghostBuilding == null)
                return;

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

            CancelPlacement();
        }

        private void CancelPlacement()
        {
            if (_ghostBuilding != null)
            {
                _poolManager.Release(_ghostBuilding.gameObject);
                _ghostBuilding = null;
            }

            _selectedBuilding = null;
            _isPlacing = false;
        }
    }
}