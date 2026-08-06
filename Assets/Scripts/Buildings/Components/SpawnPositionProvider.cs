using UnityEngine;

namespace PanteonStrategyGame.Buildings.Components
{
    public class SpawnPositionProvider : MonoBehaviour
    {
        private const int SpawnPointsPerRing = 8;
        private const float RingOffset = 0.5f;

        private float _spawnRadius;
        private float _spawnAngleStep;
        private int _spawnIndex;

        public void Initialize(
            float spawnRadius,
            float spawnAngleStep)
        {
            _spawnRadius = spawnRadius;
            _spawnAngleStep = spawnAngleStep;
            _spawnIndex = 0;
        }

        public Vector3 GetSpawnPosition()
        {
            float angle =
                _spawnIndex * _spawnAngleStep * Mathf.Deg2Rad;

            float radius =
                _spawnRadius +
                (_spawnIndex / SpawnPointsPerRing) * RingOffset;

            Vector3 offset =
                new(
                    Mathf.Cos(angle),
                    Mathf.Sin(angle),
                    0f);

            _spawnIndex++;

            return transform.position + offset * radius;
        }

        public void ResetIndex()
        {
            _spawnIndex = 0;
        }
    }
}