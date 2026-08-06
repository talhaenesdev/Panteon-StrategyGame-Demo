using PanteonStrategyGame.CameraSystem.Components;
using UnityEngine;

namespace PanteonStrategyGame.CameraSystem.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private CameraMovement _movement;

        [SerializeField]
        private CameraZoom _zoom;

        [SerializeField]
        private CameraBounds _bounds;

        private void Update()
        {
            UpdateCamera();
        }
        private void UpdateCamera()
        {
            _movement.Tick();
            _zoom.Tick();
            _bounds.Tick();
        }
    }
}