using UnityEngine;

namespace PanteonStrategyGame.Grid.Models
{
    public readonly struct MapBounds
    {
        public readonly float MinX;
        public readonly float MaxX;
        public readonly float MinY;
        public readonly float MaxY;

        public MapBounds(
            float minX,
            float maxX,
            float minY,
            float maxY)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }
    }
}