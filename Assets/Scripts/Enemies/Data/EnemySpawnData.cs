using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.Enemies.Data
{
    [System.Serializable]
    public class EnemySpawnData
    {
        [SerializeField]
        private string poolKey;

        [SerializeField]
        private Vector2Int gridPosition;

        [SerializeField]
        private UnitData unitData;

        [SerializeField]
        private BuildingData buildingData;

        public string PoolKey => poolKey;

        public Vector2Int GridPosition => gridPosition;

        public UnitData UnitData => unitData;

        public BuildingData BuildingData => buildingData;
    }
}