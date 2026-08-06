using UnityEngine;

namespace PanteonStrategyGame.CameraSystem.Data
{
    [CreateAssetMenu(
        fileName = "CameraSettings",
        menuName = "Panteon Strategy Game/Camera Settings")]
    public class CameraSettings : ScriptableObject
    {
        #region Movement

        [field: Header("Movement")]

        [field: SerializeField]
        [field: Tooltip("Camera movement speed.")]
        [field: Range(1f, 50f)]
        public float MoveSpeed { get; private set; } = 12f;

        #endregion

        #region Edge Scroll

        [field: Header("Edge Scroll")]

        [field: SerializeField]
        [field: Tooltip("Mouse distance from screen edge to start edge scrolling.")]
        [field: Range(5f, 100f)]
        public float EdgeSize { get; private set; } = 20f;

        #endregion

        #region Zoom

        [field: Header("Zoom")]

        [field: SerializeField]
        [field: Tooltip("Mouse wheel zoom speed.")]
        [field: Range(1f, 100f)]
        public float ZoomSpeed { get; private set; } = 20f;

        [field: SerializeField]
        [field: Tooltip("Minimum orthographic size.")]
        [field: Range(1f, 20f)]
        public float MinZoom { get; private set; } = 4f;

        #endregion
    }
}