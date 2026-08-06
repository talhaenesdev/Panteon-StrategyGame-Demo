using PanteonStrategyGame.CameraSystem.Data;
using UnityEngine;

namespace PanteonStrategyGame.CameraSystem.Components
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private CameraSettings _settings;

        public void Tick()
        {
            Vector3 direction =
                GetKeyboardDirection();

            direction +=
                GetScreenEdgeDirection();

            if (direction == Vector3.zero)
                return;

            transform.position +=
                direction.normalized *
                _settings.MoveSpeed *
                Time.deltaTime;
        }

        private static Vector3 GetKeyboardDirection()
        {
            return new Vector3(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));
        }

        private Vector3 GetScreenEdgeDirection()
        {
            Vector3 direction = Vector3.zero;

            Vector3 mouse =
                Input.mousePosition;

            if (mouse.x <= _settings.EdgeSize)
                direction.x--;

            if (mouse.x >= Screen.width - _settings.EdgeSize)
                direction.x++;

            if (mouse.y <= _settings.EdgeSize)
                direction.y--;

            if (mouse.y >= Screen.height - _settings.EdgeSize)
                direction.y++;

            return direction;
        }
    }
}