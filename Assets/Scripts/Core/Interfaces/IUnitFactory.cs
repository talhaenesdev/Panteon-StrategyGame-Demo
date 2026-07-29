using UnityEngine;
using PanteonStrategyGame.Units.Data;
using PanteonStrategyGame.Units.Models;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IUnitFactory
    {
        Unit Create(UnitData data, Vector3 position);
    }
}