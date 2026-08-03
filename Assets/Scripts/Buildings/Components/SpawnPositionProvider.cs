using UnityEngine;

namespace PanteonStrategyGame.Buildings.Components
{
    public class SpawnPositionProvider : MonoBehaviour
    {
        [SerializeField]
        private float radius = 1.2f;

        [SerializeField]
        private float angleStep = 45f;

        private int _spawnIndex;

        public Vector3 GetSpawnPosition()
        {
            float angle = _spawnIndex * angleStep * Mathf.Deg2Rad;

            float spiralRadius =
                radius + (_spawnIndex / 8) * 0.5f;

            Vector3 offset = new Vector3(
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