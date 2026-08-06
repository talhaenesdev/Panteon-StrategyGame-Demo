using PanteonStrategyGame.Units.Data;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Data
{
    [CreateAssetMenu(fileName = "BuildingData",  menuName = "Panteon Strategy Game/Buildings/Building Data")]
    public class BuildingData : ScriptableObject
    {
        [SerializeField, Min(0)]
        private int buildingBuffer = 0;

        public int BuildingBuffer => buildingBuffer;

        [field: SerializeField]
        public string DisplayName { get; private set; }

        [Header("General")]
        public Sprite Icon;

        [Header("Pooling")]
        [SerializeField] private string _poolKey;
        public string PoolKey => _poolKey;

        [SerializeField] private string _ghostPoolKey;
        public string GhostPoolKey => _ghostPoolKey;

        [Header("Stats")]
        public int MaxHealth;

        [Header("Placement")]
        public Vector2Int Size;

        [SerializeField]
        private UnitData[] producibleUnits;
        public IReadOnlyList<UnitData> ProducibleUnits => producibleUnits;

        [Header("Spawn Settings")]
        [SerializeField]
        private float spawnRadius = 1.2f;

        [SerializeField]
        private float spawnAngleStep = 45f;

        public float SpawnRadius => spawnRadius;
        public float SpawnAngleStep => spawnAngleStep;
    }
}