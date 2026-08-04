using UnityEngine;

namespace PanteonStrategyGame.Grid.Data
{
    [CreateAssetMenu(
        fileName = "GridSettings",
        menuName = "Panteon Strategy Game/Grid/Grid Settings")]
    public class GridSettings : ScriptableObject
    {
        [Header("Grid Size")]
        [Min(1)]
        public int Width = 20;

        [Min(1)]
        public int Height = 20;

        [Header("Cell")]
        [Min(0.1f)]
        public float CellSize = 1f;
    }
}