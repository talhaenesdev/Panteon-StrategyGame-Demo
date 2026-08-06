using PanteonStrategyGame.Common.Enums;
using UnityEngine;

namespace PanteonStrategyGame.Common.Interfaces
{
    public interface IEntity
    {

        Team Team { get; }

        Transform Transform { get; }
    }
}
