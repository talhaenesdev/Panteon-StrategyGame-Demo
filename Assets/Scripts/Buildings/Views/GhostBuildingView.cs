using UnityEngine;

namespace PanteonStrategyGame.Buildings.Views
{
    public class GhostBuildingView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer[] _renderers;

        [SerializeField]
        private Color _validColor = Color.green;

        [SerializeField]
        private Color _invalidColor = Color.red;

        public void UpdateVisual(
            Vector3 position,
            bool isValid)
        {
            SetPosition(position);
            SetValid(isValid);
        }

        private void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        private void SetValid(bool isValid)
        {
            Color targetColor = isValid
                ? _validColor
                : _invalidColor;

            foreach (SpriteRenderer renderer in _renderers)
            {
                renderer.color = targetColor;
            }
        }
    }
}