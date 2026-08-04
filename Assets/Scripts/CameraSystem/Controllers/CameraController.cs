using PanteonStrategyGame.CameraSystem.Components;
using UnityEngine;

namespace PanteonStrategyGame.CameraSystem.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private CameraMovement movement;

        [SerializeField]
        private CameraZoom zoom;

        [SerializeField]
        private CameraBounds bounds;

        private void Update()
        {
            UpdateCamera();
        }
        private void UpdateCamera()
        {
            movement.Tick();
            zoom.Tick();
            bounds.Tick();
        }
    }
}