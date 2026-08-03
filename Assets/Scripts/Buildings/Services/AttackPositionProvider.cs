using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Grid;
using PanteonStrategyGame.Pathfinding;
using UnityEngine;

namespace PanteonStrategyGame.Buildings.Services
{
    public class AttackPositionProvider : IAttackPositionProvider
    {
        private readonly GridManager _grid;

        public AttackPositionProvider(GridManager grid)
        {
            _grid = grid;
        }

        public Vector3 GetAttackPosition(
            Building building,
            Vector3 attackerPosition)
        {
            Vector2Int origin = building.OriginGridPosition;

            BuildingData data = building.BuildingData;

            float bestDistance = float.MaxValue;

            Vector3 bestPosition = building.transform.position;

            for (int x = -1; x <= data.Size.x; x++)
            {
                for (int y = -1; y <= data.Size.y; y++)
                {
                    bool border =
                        x == -1 ||
                        y == -1 ||
                        x == data.Size.x ||
                        y == data.Size.y;

                    if (!border)
                        continue;

                    Vector2Int cell =
                        origin + new Vector2Int(x, y);

                    GridNode node =
                        _grid.GetNode(_grid.GetWorldPosition(cell));

                    if (node == null || !node.Walkable)
                        continue;

                    float distance =
                        Vector3.Distance(
                            attackerPosition,
                            node.WorldPosition);

                    if (distance < bestDistance)
                    {
                        bestDistance = distance;
                        bestPosition = node.WorldPosition;
                    }
                }
            }

            return bestPosition;
        }
    }
}