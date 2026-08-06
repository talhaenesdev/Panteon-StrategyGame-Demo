using PanteonStrategyGame.Common.Enums;
using UnityEngine;

public interface IEntity
{

    Team Team { get; }

    Transform Transform { get; }
}