using PanteonStrategyGame.CameraSystem.Data;
using PanteonStrategyGame.Grid.Interfaces;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.CameraSystem.Components
{
    [RequireComponent(typeof(Camera))]
    public class CameraZoom : MonoBehaviour
    {
        [Inject]
        private IMapInfoProvider _mapInfoProvider;
        [SerializeField]
        private CameraSettings settings;

        private Camera _camera;
        private float _maxZoom;

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
            float zoomInput =
                ReadZoomInput();

            ApplyZoom(zoomInput);
        }

        private float ReadZoomInput()
        {
            return Input.mouseScrollDelta.y;
        }

        private void ApplyZoom(float zoomInput)
        {
            if (Mathf.Abs(zoomInput) < Mathf.Epsilon)
                return;

            _camera.orthographicSize -=
                zoomInput *
                settings.ZoomSpeed *
                Time.deltaTime;

            _camera.orthographicSize =
                Mathf.Clamp(
                    _camera.orthographicSize,
                    settings.MinZoom,
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

            _maxZoom =
                Mathf.Min(verticalZoom, horizontalZoom);
        }
    }
}