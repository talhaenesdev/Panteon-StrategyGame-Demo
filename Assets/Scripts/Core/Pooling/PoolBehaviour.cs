using UnityEngine;

namespace PanteonStrategyGame.Core.Pooling
{
    public class PoolBehaviour : MonoBehaviour
    {
        [SerializeField]
        private string poolKey;

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        private int initialSize = 10;

        public string PoolKey => poolKey;

        public GameObject Prefab => prefab;

        public int InitialSize => initialSize;
    }
}