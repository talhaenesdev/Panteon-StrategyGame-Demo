using UnityEngine;

namespace PanteonStrategyGame.CameraSystem.Data
{
    [CreateAssetMenu(
        fileName = "CameraSettings",
        menuName = "Panteon Strategy Game/Camera Settings")]
    public class CameraSettings : ScriptableObject
    {
        [Header("Movement")]
        public float MoveSpeed = 12f;

        [Header("Edge Scroll")]
        public float EdgeSize = 20f;

        [Header("Zoom")]
        public float ZoomSpeed = 20f;
        public float MinZoom = 4f;
    }
}