using UnityEngine;

namespace PanteonStrategyGame.Buildings.Views
{
    public class GhostBuildingView : MonoBehaviour
    {
        private SpriteRenderer[] _renderers;

        private void Awake()
        {
            _renderers = GetComponentsInChildren<SpriteRenderer>();
        }

        public void SetValid(bool isValid)
        {
            Color color = isValid ? Color.green : Color.red;
            color.a = 0.5f;

            foreach (var renderer in _renderers)
            {
                renderer.color = color;
            }
        }
    }
}