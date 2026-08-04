using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Units.Components
{
    public class UnitTeamMaterial : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [Inject]
        private ITeamMaterialService _teamMaterialService;

        private void Awake()
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void SetTeam(Team team)
        {
            Material material =
                _teamMaterialService.GetMaterial(team);

            if (material != null)
            {
                spriteRenderer.sharedMaterial = material;
            }
        }
    }
}