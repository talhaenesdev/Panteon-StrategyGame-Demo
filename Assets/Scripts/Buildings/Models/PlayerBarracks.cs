using System.Collections.Generic;
using PanteonStrategyGame.Buildings.Components;
using PanteonStrategyGame.Units.Data;
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

        public Vector3 GetSpawnPosition()
        {
            return spawnPositionProvider.GetSpawnPosition();
        }
    }
}