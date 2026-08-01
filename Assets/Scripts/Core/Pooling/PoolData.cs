using UnityEngine;

namespace PanteonStrategyGame.Core.Pooling
{
    [System.Serializable]
    public class PoolData
    {
        [SerializeField]
        private string poolKey;
        public string PoolKey => poolKey;

        [SerializeField]
        private GameObject prefab;
        public GameObject Prefab => prefab;

        [SerializeField]
        private int initialSize = 10;
        public int InitialSize => initialSize;
    }
}