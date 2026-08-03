using PanteonStrategyGame.Units.Models;
using UnityEngine;

namespace PanteonStrategyGame.Units.Components
{
    public class UnitSeparation : MonoBehaviour
    {
        [SerializeField] private float radius = 0.7f;
        [SerializeField] private float force = 2f;

        private readonly Collider2D[] _results = new Collider2D[16];

        private void LateUpdate()
        {
            int count = Physics2D.OverlapCircleNonAlloc(
                transform.position,
                radius,
                _results);

            Vector2 push = Vector2.zero;

            for (int i = 0; i < count; i++)
            {
                Collider2D col = _results[i];

                if (col == null)
                    continue;

                if (col.gameObject == gameObject)
                    continue;

                if (!col.TryGetComponent<Unit>(out _))
                    continue;

                Vector2 dir =
                    (Vector2)(transform.position - col.transform.position);

                float distance = dir.magnitude;

                if (distance <= 0.001f)
                    continue;

                push += dir.normalized / distance;
            }

            transform.position +=
                (Vector3)(push * force * Time.deltaTime);
        }
    }
}