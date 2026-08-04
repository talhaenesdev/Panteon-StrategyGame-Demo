using PanteonStrategyGame.Common.Enums;
using UnityEngine;

namespace PanteonStrategyGame.Units.Components
{
    public class UnitTeamMaterial : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Material playerMaterial;

        [SerializeField]
        private Material enemyMaterial;

        private void Awake()
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void SetTeam(Team team)
        {
            switch (team)
            {
                case Team.Player:
                    spriteRenderer.sharedMaterial = playerMaterial;
                    break;

                case Team.Enemy:
                    spriteRenderer.sharedMaterial = enemyMaterial;
                    break;
            }
        }
    }
}