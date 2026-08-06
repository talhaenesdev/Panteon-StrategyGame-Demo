using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.Enemies.Data
{
    [System.Serializable]
    public class EnemySpawnData
    {
        [SerializeField]
        private string _poolKey;

        [SerializeField]
        private Vector2Int _gridPosition;

        [SerializeField]
        private UnitData _unitData;

        [SerializeField]
        private BuildingData _buildingData;

        public string PoolKey => _poolKey;

        public Vector2Int GridPosition => _gridPosition;

        public UnitData UnitData => _unitData;

        public BuildingData BuildingData => _buildingData;
    }
}