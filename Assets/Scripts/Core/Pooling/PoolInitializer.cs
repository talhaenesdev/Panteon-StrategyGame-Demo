using PanteonStrategyGame.Core.Pooling;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Core
{
    public class PoolInitializer : MonoBehaviour
    {
        [Inject]
        private PoolManager _poolManager;

        private void Start()
        {
            _poolManager.Initialize();
        }
    }
}