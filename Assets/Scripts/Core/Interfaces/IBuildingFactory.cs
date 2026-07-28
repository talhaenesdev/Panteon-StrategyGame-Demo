using UnityEngine;
using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IBuildingFactory
    {
        Building Create(BuildingData data, Vector3 position);
    }
}