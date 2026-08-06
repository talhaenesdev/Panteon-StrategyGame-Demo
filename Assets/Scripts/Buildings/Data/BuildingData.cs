using System.Collections.Generic;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Data
{
    [CreateAssetMenu(
        fileName = "BuildingData",
        menuName = "Panteon Strategy Game/Buildings/Building Data")]
    public class BuildingData : ScriptableObject
    {
        [field: Header("Production")]

        [field: SerializeField]
        public bool CanProduceUnits { get; private set; }
        #region General

        [field: Header("General")]

        [field: SerializeField]
        public string DisplayName { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }

        #endregion

        #region Pooling

        [field: Header("Pooling")]

        [field: SerializeField]
        public string PoolKey { get; private set; }

        [field: SerializeField]
        public string GhostPoolKey { get; private set; }

        #endregion

        #region Stats

        [field: Header("Stats")]

        [field: SerializeField]
        [field: Min(1)]
        public int MaxHealth { get; private set; } = 100;

        #endregion

        #region Placement

        [field: Header("Placement")]

        [field: SerializeField]
        public Vector2Int Size { get; private set; } = Vector2Int.one;

        [field: SerializeField]
        [field: Tooltip("Empty cells required around this building.")]
        [field: Range(0, 5)]
        public int BuildingBuffer { get; private set; }

        #endregion

        #region Production

        [Header("Production")]

        [SerializeField]
        private UnitData[] producibleUnits;

        public IReadOnlyList<UnitData> ProducibleUnits =>
            producibleUnits;

        #endregion

        #region Spawn

        [field: Header("Spawn")]

        [field: SerializeField]
        [field: Tooltip("Radius around the building where units will spawn.")]
        [field: Range(0.5f, 5f)]
        public float SpawnRadius { get; private set; } = 1.2f;

        [field: SerializeField]
        [field: Tooltip("Angle increment between consecutive spawned units.")]
        [field: Range(10f, 180f)]
        public float SpawnAngleStep { get; private set; } = 45f;

        #endregion
    }
}