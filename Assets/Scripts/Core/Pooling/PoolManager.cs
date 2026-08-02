using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Core.Pooling
{
    public class PoolManager
    {
        private readonly Dictionary<string, Pool> _pools = new();
        private readonly Dictionary<GameObject, Pool> _spawnedObjects = new();

        private readonly DiContainer _container;
        private readonly PoolDatabase _database;

        private readonly Transform _runtimePoolParent;

        public PoolManager(
            DiContainer container,
            PoolDatabase database)
        {
            _container = container;
            _database = database;

            GameObject runtimePools = new GameObject("RuntimePools");

            _runtimePoolParent = runtimePools.transform;
        }

        public void Initialize()
        {
            foreach (PoolData pool in _database.Pools)
            {
                Register(
                    pool.PoolKey,
                    pool.Prefab,
                    pool.InitialSize);
            }
        }

        public void Register(
            string poolKey,
            GameObject prefab,
            int initialSize)
        {
            if (_pools.ContainsKey(poolKey))
                return;

            GameObject poolRoot = new GameObject(poolKey + " Pool");
            poolRoot.transform.SetParent(_runtimePoolParent);

            Pool pool = new Pool(
                _container,
                prefab,
                poolRoot.transform,
                initialSize);

            _pools.Add(poolKey, pool);
        }

        public GameObject Get(
            string poolKey,
            Transform parent = null)
        {
            if (!_pools.TryGetValue(poolKey, out Pool pool))
            {
                UnityEngine.Debug.LogError($"Pool bulunamadı : {poolKey}");

                return null;
            }

            GameObject obj =
                pool.Get(parent);

            _spawnedObjects[obj] = pool;

            return obj;
        }

        public void Release(GameObject obj)
        {
            if (_spawnedObjects.TryGetValue(obj, out Pool pool))
            {
                pool.Release(obj);

                _spawnedObjects.Remove(obj);
            }
            else
            {
                Object.Destroy(obj);
            }
        }
    }
}