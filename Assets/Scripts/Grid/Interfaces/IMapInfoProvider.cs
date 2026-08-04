using PanteonStrategyGame.Grid.Models;
using UnityEngine;

namespace PanteonStrategyGame.Grid.Interfaces
{
    public interface IMapInfoProvider
    {
        Vector2 MapSize { get; }

        MapBounds MapBounds { get; }
    }
}