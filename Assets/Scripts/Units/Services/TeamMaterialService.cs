using System.Collections.Generic;
using PanteonStrategyGame.Common.Enums;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Models;
using UnityEngine;

namespace PanteonStrategyGame.Units.Services
{
    public class TeamMaterialService : ITeamMaterialService
    {
        private readonly Dictionary<Team, Material> _materials;

        public TeamMaterialService(
            List<TeamMaterialEntry> entries)
        {
            _materials = new Dictionary<Team, Material>();

            foreach (TeamMaterialEntry entry in entries)
            {
                if (!_materials.ContainsKey(entry.Team))
                {
                    _materials.Add(entry.Team, entry.Material);
                }
            }
        }

        public Material GetMaterial(Team team)
        {
            if (_materials.TryGetValue(team, out Material material))
                return material;

            Debug.LogWarning($"No material found for Team : {team}");

            return null;
        }
    }
}