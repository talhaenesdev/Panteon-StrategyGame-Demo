using PanteonStrategyGame.Common.Enums;
using UnityEngine;

public interface IEntity
{
    string Id { get; }

    Team Team { get; }

    Transform Transform { get; }
}