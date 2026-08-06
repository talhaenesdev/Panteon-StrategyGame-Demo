using UnityEngine;

namespace PanteonStrategyGame.Enemies.Data
{
    [CreateAssetMenu(
        fileName = "EnemyBaseLayout",
        menuName = "Panteon Strategy Game/Enemies/Base Layout")]
    public class EnemyBaseLayout : ScriptableObject
    {
        [SerializeField]
        private EnemySpawnData[] _spawns;

        public EnemySpawnData[] Spawns => _spawns;
    }
}