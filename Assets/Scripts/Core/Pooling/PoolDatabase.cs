using System.Collections.Generic;
using UnityEngine;

namespace PanteonStrategyGame.Core.Pooling
{
    [CreateAssetMenu(
        fileName = "PoolDatabase",
        menuName = "Panteon Strategy Game/Pooling/Pool Database")]
    public class PoolDatabase : ScriptableObject
    {
        [SerializeField]
        private List<PoolData> pools = new();

        public IReadOnlyList<PoolData> Pools => pools;
    }
}