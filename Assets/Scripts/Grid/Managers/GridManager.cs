using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using PanteonStrategyGame.Grid.Data;
using PanteonStrategyGame.Grid.Interfaces;
using PanteonStrategyGame.Grid.Models;
using PanteonStrategyGame.Pathfinding;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PanteonStrategyGame.Grid.Managers
{
    public class GridManager : MonoBehaviour, IMapInfoProvider
    {
        [SerializeField]
        private GridSettings _settings;

        private GridCell[,] _cells;
        private GridNode[,] _nodes;

        private void Awake()
        {
            CreateGrid();
        }
        public Vector2 MapSize =>
    new(
        _settings.Width * _settings.CellSize,
        _settings.Height * _settings.CellSize);

        public MapBounds MapBounds {  get; private set; }

        private void CreateGrid()
        {
            _cells = new GridCell[_settings.Width, _settings.Height];
            _nodes = new GridNode[_settings.Width, _settings.Height];

            for (int x = 0; x < _settings.Width; x++)
            {
                for (int y = 0; y < _settings.Height; y++)
                {
                    Vector2Int gridPosition = new Vector2Int(x, y);

                    Vector3 worldPosition =
                        GetWorldPosition(gridPosition);

                    _cells[x, y] = new GridCell(gridPosition);

                    _nodes[x, y] = new GridNode(
                        gridPosition,
                        worldPosition,
                        true);
                }
            }
        }

        public bool IsInsideGrid(Vector2Int position)
        {
            return position.x >= 0 &&
                   position.x < _settings.Width &&
                   position.y >= 0 &&
                   position.y < _settings.Height;
        }

        public GridCell GetCell(Vector2Int position)
        {
            if (!IsInsideGrid(position))
                return null;

            return _cells[position.x, position.y];
        }

        public GridNode GetNode(Vector3 worldPosition)
        {
            Vector2Int gridPosition =
                GetGridPosition(worldPosition);

            if (!IsInsideGrid(gridPosition))
                return null;

            return _nodes[gridPosition.x, gridPosition.y];
        }

        public IEnumerable<GridNode> GetAllNodes()
        {
            foreach (GridNode node in _nodes)
            {
                yield return node;
            }
        }

        public List<GridNode> GetNeighbours(GridNode node)
        {
            List<GridNode> neighbours = new();

            Vector2Int[] directions =
            {
                Vector2Int.up,
                Vector2Int.down,
                Vector2Int.left,
                Vector2Int.right
            };

            foreach (Vector2Int direction in directions)
            {
                Vector2Int neighbourPosition =
                    node.GridPosition + direction;

                if (!IsInsideGrid(neighbourPosition))
                    continue;

                neighbours.Add(
                    _nodes[neighbourPosition.x, neighbourPosition.y]);
            }

            return neighbours;
        }
        
       
        public void SetWalkable(Vector2Int position, bool walkable)
        {
            if (!IsInsideGrid(position))
                return;

            _nodes[position.x, position.y].Walkable = walkable;
        }

        public Vector3 GetWorldPosition(Vector2Int gridPosition)
        {
            return transform.position + new Vector3(
                gridPosition.x * _settings.CellSize,
                gridPosition.y * _settings.CellSize,
                0f);
        }

        public Vector3 GetBuildingCenterPosition(
            Vector2Int origin,
            Vector2Int size)
        {
            float offsetX =
                (size.x - 1) * _settings.CellSize * 0.5f;

            float offsetY =
                (size.y - 1) * _settings.CellSize * 0.5f;

            return GetWorldPosition(origin) +
                   new Vector3(offsetX, offsetY, 0f);
        }

        public Vector2Int GetGridPosition(Vector3 worldPosition)
        {
            Vector3 localPosition =
                worldPosition - transform.position;

            return new Vector2Int(
                Mathf.RoundToInt(localPosition.x / _settings.CellSize),
                Mathf.RoundToInt(localPosition.y / _settings.CellSize));
        }

        public void PlaceBuilding(
            Building building,
            BuildingData data,
            Vector2Int origin)
        {
            for (int x = 0; x < data.Size.x; x++)
            {
                for (int y = 0; y < data.Size.y; y++)
                {
                    Vector2Int position =
                        origin + new Vector2Int(x, y);

                    GetCell(position).Occupy(building);

                    SetWalkable(position, false);
                }
            }
        }

        public void RemoveBuilding(Building building)
        {
            BuildingData data = building.BuildingData;

            Vector2Int origin =
                building.OriginGridPosition;

            for (int x = 0; x < data.Size.x; x++)
            {
                for (int y = 0; y < data.Size.y; y++)
                {
                    Vector2Int position =
                        origin + new Vector2Int(x, y);

                    if (!IsInsideGrid(position))
                        continue;

                    GetCell(position).Clear();

                    SetWalkable(position, true);
                }
            }
        }


        public MapBounds GetMapBounds()
        {
            float minX = transform.position.x;
            float minY = transform.position.y;

            float maxX =
                transform.position.x + (_settings.Width - 1) * _settings.CellSize;

            float maxY =
                transform.position.y + (_settings.Height - 1) * _settings.CellSize;

            return new MapBounds(
                minX,
                maxX,
                minY,
                maxY);
        }

        public GridNode GetClosestAttackNode(
            Vector3 attackerPosition,
            Vector3 targetPosition,
            float attackRange)
        {
            Vector2Int targetGrid =
                GetGridPosition(targetPosition);

            GridNode bestNode = null;

            float bestDistance = float.MaxValue;

            int radius =
                Mathf.CeilToInt(
                    attackRange / _settings.CellSize) + 1;

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    Vector2Int pos =
                        targetGrid + new Vector2Int(x, y);

                    if (!IsInsideGrid(pos))
                        continue;

                    GridNode node =
                        _nodes[pos.x, pos.y];

                    if (!node.Walkable)
                        continue;

                    float distanceToTarget =
                        Vector3.Distance(
                            node.WorldPosition,
                            targetPosition);

                    if (distanceToTarget > attackRange)
                        continue;

                    float distanceToAttacker =
                        Vector3.Distance(
                            attackerPosition,
                            node.WorldPosition);

                    if (distanceToAttacker < bestDistance)
                    {
                        bestDistance = distanceToAttacker;
                        bestNode = node;
                    }
                }
            }

            return bestNode;
        }


#if UNITY_EDITOR

        [SerializeField]
        private bool drawWalkableGizmos = true;

        private void OnDrawGizmos()
        {
            if (!drawWalkableGizmos)
                return;

            if (_nodes == null)
                return;

            foreach (GridNode node in _nodes)
            {
                if (node == null)
                    continue;

                Gizmos.color = node.Walkable
                    ? new Color(0f, 1f, 0f, .35f)
                    : new Color(1f, 0f, 0f, .35f);

                Gizmos.DrawWireCube(
                    node.WorldPosition,
                    Vector3.one * _settings.CellSize);
            }
        }

#endif
    }
}