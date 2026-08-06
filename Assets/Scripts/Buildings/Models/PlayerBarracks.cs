using System.Collections.Generic;
using PanteonStrategyGame.Buildings.Components;
using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Units.Data;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Models
{
    public class PlayerBarracks : Building
    {
        #region Inspector

        [SerializeField]
        private ProductionComponent _productionComponent;

        [SerializeField]
        private SpawnPositionProvider _spawnPositionProvider;

        #endregion

        #region Properties

        public ProductionComponent ProductionComponent => _productionComponent;

        public IReadOnlyList<UnitData> ProducibleUnits =>
            BuildingData.ProducibleUnits;

        #endregion

        #region Initialization

        public override void Initialize(
            BuildingData data,
            Vector2Int originGridPosition)
        {
            base.Initialize(data, originGridPosition);

            _spawnPositionProvider.Initialize(
                data.SpawnRadius,
                data.SpawnAngleStep);
        }

        #endregion

        #region Spawn

        public Vector3 GetSpawnPosition() =>
            _spawnPositionProvider.GetSpawnPosition();

        #endregion
    }
}