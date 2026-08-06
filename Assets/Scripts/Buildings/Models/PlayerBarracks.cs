using PanteonStrategyGame.Buildings.Components;
using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Units.Data;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Models
{
    public class PlayerBarracks : Building
    {
        public virtual bool IsControllable => true;
        [SerializeField]
        private ProductionComponent productionComponent;

        [SerializeField]
        private SpawnPositionProvider spawnPositionProvider;

        public ProductionComponent ProductionComponent => productionComponent;

        public override string DisplayName => BuildingData.DisplayName;

        public override Sprite Icon => BuildingData.Icon;

        public IReadOnlyList<UnitData> ProducibleUnits =>
            BuildingData.ProducibleUnits;
        public override void Initialize(
            BuildingData data,
            Vector2Int originGridPosition)
        {
            base.Initialize(data, originGridPosition);

            spawnPositionProvider.Initialize(
                data.SpawnRadius,
                data.SpawnAngleStep);
        }

        public Vector3 GetSpawnPosition()
        {
            return spawnPositionProvider.GetSpawnPosition();
        }
        
    }
}