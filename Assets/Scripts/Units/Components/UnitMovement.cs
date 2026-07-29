using System.Collections.Generic;
using UnityEngine;

namespace PanteonStrategyGame.Units.Components
{
    public class UnitMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3f;

        private readonly Queue<Vector3> _path = new();

        private void Update()
        {
            if (_path.Count == 0)
                return;

            Vector3 target = _path.Peek();

            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                moveSpeed * Time.deltaTime);


            if (Vector3.Distance(transform.position, target) < 0.05f)
            {
                Debug.Log($"Reached : {target}");

                _path.Dequeue();
            }
        }


        public void SetPath(List<Vector3> path)
        {
            _path.Clear();

            foreach (Vector3 point in path)
            {
                _path.Enqueue(point);
            }

            Debug.Log($"New Path Count : {_path.Count}");
        }
    }
}