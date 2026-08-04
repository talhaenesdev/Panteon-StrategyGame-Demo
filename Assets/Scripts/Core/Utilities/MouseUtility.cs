using UnityEngine;

namespace PanteonStrategyGame.Core.Utilities
{
    public static class MouseUtility
    {
        public static Vector3 GetMouseWorldPosition(Camera camera)
        {
            Vector3 mouseWorld =
                camera.ScreenToWorldPoint(Input.mousePosition);

            mouseWorld.z = 0f;

            return mouseWorld;
        }
    }
}