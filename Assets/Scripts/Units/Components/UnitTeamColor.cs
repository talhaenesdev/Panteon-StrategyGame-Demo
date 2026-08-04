using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Common.Entities;
using UnityEngine;

namespace PanteonStrategyGame.Units.Components
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class UnitTeamColor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetTeam(Team team)
        {
            switch (team)
            {
                case Team.Player:
                    spriteRenderer.color = Color.blue;
                    break;

                case Team.Enemy:
                    spriteRenderer.color = Color.red;
                    break;

                default:
                    spriteRenderer.color = Color.white;
                    break;
            }
        }
    }
}