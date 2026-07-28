using UnityEngine;

namespace PanteonStrategyGame.Buildings.Views
{
    public class GhostBuilding : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] spriteRenderers;

        public void SetValid(bool isValid)
        {
            Color color = isValid ? Color.green : Color.red;
            color.a = 0.5f;

            foreach (var renderer in spriteRenderers)
            {
                renderer.color = color;
            }
        }
    }
}