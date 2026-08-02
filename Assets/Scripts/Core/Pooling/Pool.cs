using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Core.Pooling
{
    public class Pool
    {
        private readonly DiContainer _container;
        private readonly GameObject _prefab;
        private readonly Transform _poolParent;

        private readonly Queue<GameObject> _objects = new();

        public Pool(
            DiContainer container,
            GameObject prefab,
            Transform parent,
            int initialSize)
        {
            _container = container;
            _prefab = prefab;
            _poolParent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                GameObject obj = CreateObject();

                obj.SetActive(false);

                _objects.Enqueue(obj);
            }
        }

        private GameObject CreateObject()
        {
            GameObject obj =
                _container.InstantiatePrefab(
                    _prefab,
                    _poolParent);

            obj.SetActive(false);

            return obj;
        }

        public GameObject Get(Transform parent = null)
        {
            GameObject obj;

            if (_objects.Count > 0)
            {
                obj = _objects.Dequeue();
            }
            else
            {
                obj = CreateObject();
            }

            obj.transform.SetParent(
                parent == null
                    ? null
                    : parent,
                false);

            obj.SetActive(true);

            return obj;
        }

        public void Release(GameObject obj)
        {
            obj.transform.SetParent(
                _poolParent,
                false);

            obj.SetActive(false);

            _objects.Enqueue(obj);
        }
    }
}