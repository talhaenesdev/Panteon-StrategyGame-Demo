using PanteonStrategyGame.CameraSystem.Data;
using PanteonStrategyGame.Grid.Interfaces;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.CameraSystem.Components
{
    [RequireComponent(typeof(Camera))]
    public class CameraZoom : MonoBehaviour
    {
        #region Inject

        [Inject]
        private IMapInfoProvider _mapInfoProvider;

        #endregion

        #region Inspector

        [SerializeField]
        private CameraSettings _settings;

        #endregion

        #region Runtime

        private Camera _camera;
        private float _maxZoom;

        #endregion

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Start()
        {
            CalculateMaxZoom();
        }

        public void Tick()
        {
            float zoomInput = Input.mouseScrollDelta.y;

            if (Mathf.Approximately(zoomInput, 0f))
                return;

            _camera.orthographicSize -=
                zoomInput *
                _settings.ZoomSpeed *
                Time.deltaTime;

            _camera.orthographicSize = Mathf.Clamp(
                _camera.orthographicSize,
                _settings.MinZoom,
                _maxZoom);
        }

        private void CalculateMaxZoom()
        {
            Vector2 mapSize =
                _mapInfoProvider.MapSize;

            float verticalZoom =
                mapSize.y * 0.5f;

            float horizontalZoom =
                mapSize.x /
                (_camera.aspect * 2f);

            _maxZoom =
                Mathf.Min(
                    verticalZoom,
                    horizontalZoom);
        }
    }
}