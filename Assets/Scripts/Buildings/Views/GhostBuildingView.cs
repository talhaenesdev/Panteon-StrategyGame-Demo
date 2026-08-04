using UnityEngine;

namespace PanteonStrategyGame.Buildings.Views
{
    public class GhostBuildingView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer[] renderers;

        [SerializeField]
        private Color validColor = Color.green;

        [SerializeField]
        private Color invalidColor = Color.red;

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
                ? validColor
                : invalidColor;

            foreach (SpriteRenderer renderer in renderers)
            {
                renderer.color = targetColor;
            }
        }
    }
}