using PanteonStrategyGame.Common.Enums;
using UnityEngine;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface ITeamMaterialService
    {
        Material GetMaterial(Team team);
    }
}