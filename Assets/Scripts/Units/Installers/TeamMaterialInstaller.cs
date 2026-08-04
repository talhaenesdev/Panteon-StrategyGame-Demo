using System.Collections.Generic;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Units.Models;
using PanteonStrategyGame.Units.Services;
using UnityEngine;
using Zenject;

namespace PanteonStrategyGame.Units.Installers
{
    public class TeamMaterialInstaller : MonoInstaller
    {
        [SerializeField]
        private List<TeamMaterialEntry> teamMaterials;

        public override void InstallBindings()
        {
            Container.Bind<ITeamMaterialService>()
                .To<TeamMaterialService>()
                .AsSingle()
                .WithArguments(teamMaterials);
        }
    }
}