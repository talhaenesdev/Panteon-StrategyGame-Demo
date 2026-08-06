using UnityEngine;

namespace PanteonStrategyGame.Grid.Data
{
    [CreateAssetMenu(
        fileName = "GridSettings",
        menuName = "Panteon Strategy Game/Grid/Grid Settings")]
    public class GridSettings : ScriptableObject
    {
        #region Grid

        [field: Header("Grid")]

        [field: SerializeField]
        [field: Tooltip("Number of cells on the X axis.")]
        [field: Range(5, 500)]
        public int Width { get; private set; } = 20;

        [field: SerializeField]
        [field: Tooltip("Number of cells on the Y axis.")]
        [field: Range(5, 500)]
        public int Height { get; private set; } = 20;

        #endregion

        #region Cell

        [field: Header("Cell")]

        [field: SerializeField]
        [field: Tooltip("World size of a single grid cell.")]
        [field: Range(0.25f, 5f)]
        public float CellSize { get; private set; } = 1f;

        #endregion
    }
}