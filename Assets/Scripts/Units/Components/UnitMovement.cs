using System.Collections.Generic;
using UnityEngine;

namespace PanteonStrategyGame.Units.Components
{
    public class UnitMovement : MonoBehaviour
    {
        private readonly Queue<Vector3> _path = new();

        private float _moveSpeed;

        public bool HasPath => _path.Count > 0;

        public void Initialize(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }

        private void Update()
        {
            if (_path.Count > 0)
            {
                Debug.Log($"Moving -> {_path.Peek()}");
            }
            if (_path.Count == 0)
                return;

            Vector3 target = _path.Peek();

            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                _moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) < 0.05f)
            {
                _path.Dequeue();
            }

        }

        public void SetPath(List<Vector3> path)
        {
            _path.Clear();

            Debug.Log($"SetPath : {(path == null ? 0 : path.Count)}");

            if (path == null)
                return;

            foreach (Vector3 point in path)
            {
                _path.Enqueue(point);
            }
        }

        public void Stop()
        {
            _path.Clear();
        }
    }
}