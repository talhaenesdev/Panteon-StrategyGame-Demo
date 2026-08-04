using PanteonStrategyGame.CameraSystem.Data;
using UnityEngine;

namespace PanteonStrategyGame.CameraSystem.Components
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private CameraSettings settings;

        public void Tick()
        {
            Vector3 direction =
                GetKeyboardDirection() +
                GetEdgeDirection();

            Move(direction);
        }

        private Vector3 GetKeyboardDirection()
        {
            return new Vector3(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"),
                0f);
        }

        private Vector3 GetEdgeDirection()
        {
            Vector3 direction = Vector3.zero;

            Vector3 mouse =
                Input.mousePosition;

            if (mouse.x <= settings.EdgeSize)
                direction.x--;

            if (mouse.x >= Screen.width - settings.EdgeSize)
                direction.x++;

            if (mouse.y <= settings.EdgeSize)
                direction.y--;

            if (mouse.y >= Screen.height - settings.EdgeSize)
                direction.y++;

            return direction;
        }

        private void Move(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            transform.position +=
                settings.MoveSpeed * Time.deltaTime * direction.normalized;
        }
    }
}