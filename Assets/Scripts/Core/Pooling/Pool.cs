using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Core.Pooling
{
    public class Pool
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Queue<GameObject> _objects = new();

        private readonly DiContainer _container;

        public Pool(
            DiContainer container,
            GameObject prefab,
            Transform parent,
            int initialSize)
        {
            _container = container;
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                GameObject obj =
                    _container.InstantiatePrefab(
                        _prefab,
                        _parent);

                obj.SetActive(false);

                _objects.Enqueue(obj);
            }
        }

        public GameObject Get()
        {
            if (_objects.Count > 0)
            {
                GameObject obj = _objects.Dequeue();

                obj.SetActive(true);

                return obj;
            }

            return _container.InstantiatePrefab(
                _prefab,
                _parent);
        }

        public void Release(GameObject obj)
        {
            obj.SetActive(false);

            _objects.Enqueue(obj);
        }
    }
}