using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Common.Interfaces;
using PanteonStrategyGame.Enemies.Data;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Enemies.Spawners
{
    public class EnemyBaseSpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyBaseLayout layout;

        [Inject]
        private IEntitySpawnService _spawnService;

        private void Start()
        {
            foreach (EnemySpawnData spawn in layout.Spawns)
            {
                if (spawn.UnitData != null)
                {
                    _spawnService.SpawnUnit(
                        spawn.PoolKey,
                        spawn.UnitData,
                        spawn.GridPosition,
                        Team.Enemy);

                    continue;
                }

                if (spawn.BuildingData != null)
                {
                    _spawnService.SpawnBuilding(
                        spawn.PoolKey,
                        spawn.BuildingData,
                        spawn.GridPosition,
                        Team.Enemy);
                }
            }
        }
    }
}