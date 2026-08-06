using UnityEngine;

namespace PanteonStrategyGame.Buildings.Components
{
    public class SpawnPositionProvider : MonoBehaviour
    {
        private float _radius;
        private float _angleStep;
        private int _spawnIndex;

        public void Initialize(float radius, float angleStep)
        {
            _radius = radius;
            _angleStep = angleStep;
        }

        public Vector3 GetSpawnPosition()
        {
            float angle = _spawnIndex * _angleStep * Mathf.Deg2Rad;

            float spiralRadius =
                _radius + (_spawnIndex / 8) * 0.5f;

            Vector3 offset =
                new Vector3(
                    Mathf.Cos(angle),
                    Mathf.Sin(angle),
                    0f) * spiralRadius;

            _spawnIndex++;

            return transform.position + offset;
        }

        public void ResetIndex()
        {
            _spawnIndex = 0;
        }
    }
}