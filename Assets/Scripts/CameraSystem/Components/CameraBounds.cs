using PanteonStrategyGame.Grid;
using PanteonStrategyGame.Grid.Models;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.CameraSystem.Components
{
    [RequireComponent(typeof(Camera))]
    public class CameraBounds : MonoBehaviour
    {
        #region Inject

        [Inject]
        private GridManager _gridManager;

        #endregion

        #region Runtime

        private Camera _camera;
        private MapBounds _mapBounds;

        #endregion

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Start()
        {
            _mapBounds =
                _gridManager.GetMapBounds();
        }

        public void Tick()
        {
            float halfHeight =
                _camera.orthographicSize;

            float halfWidth =
                halfHeight *
                _camera.aspect;

            Vector3 position =
                transform.position;

            position.x = Mathf.Clamp(
                position.x,
                _mapBounds.MinX + halfWidth,
                _mapBounds.MaxX - halfWidth);

            position.y = Mathf.Clamp(
                position.y,
                _mapBounds.MinY + halfHeight,
                _mapBounds.MaxY - halfHeight);

            transform.position =
                position;
        }
    }
}