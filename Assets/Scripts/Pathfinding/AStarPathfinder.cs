using System.Collections.Generic;
using UnityEngine;
using PanteonStrategyGame.Core.Interfaces;
using PanteonStrategyGame.Grid;

namespace PanteonStrategyGame.Pathfinding
{
    public class AStarPathfinder : IPathfindingService
    {
        private readonly GridManager _gridManager;

        public AStarPathfinder(GridManager gridManager)
        {
            _gridManager = gridManager;
        }

        public List<Vector3> FindPath(Vector3 start, Vector3 target)
        {
            GridNode startNode = _gridManager.GetNode(start);
            GridNode targetNode = _gridManager.GetNode(target);

            if (startNode == null || targetNode == null)
                return new List<Vector3>();

            if (!targetNode.Walkable)
            {
                targetNode = GetClosestWalkableNode(targetNode);

                if (targetNode == null)
                    return new List<Vector3>();
            }

            foreach (GridNode node in _gridManager.GetAllNodes())
            {
                node.ResetPathData();
            }

            List<GridNode> openSet = new();
            HashSet<GridNode> closedSet = new();

            startNode.GCost = 0;
            startNode.HCost = GetDistance(startNode, targetNode);

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                GridNode currentNode = openSet[0];

                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].FCost < currentNode.FCost ||
                        (openSet[i].FCost == currentNode.FCost &&
                         openSet[i].HCost < currentNode.HCost))
                    {
                        currentNode = openSet[i];
                    }
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                    return RetracePath(startNode, targetNode);

                foreach (GridNode neighbour in _gridManager.GetNeighbours(currentNode))
                {
                    if (!neighbour.Walkable || closedSet.Contains(neighbour))
                        continue;

                    int newCost = currentNode.GCost + GetDistance(currentNode, neighbour);

                    if (newCost < neighbour.GCost || !openSet.Contains(neighbour))
                    {
                        neighbour.GCost = newCost;
                        neighbour.HCost = GetDistance(neighbour, targetNode);
                        neighbour.Parent = currentNode;

                        if (!openSet.Contains(neighbour))
                            openSet.Add(neighbour);
                    }
                }
            }

            return new List<Vector3>();
        }

        private GridNode GetClosestWalkableNode(GridNode target)
        {
            Queue<GridNode> queue = new();
            HashSet<GridNode> visited = new();

            queue.Enqueue(target);
            visited.Add(target);

            while (queue.Count > 0)
            {
                GridNode current = queue.Dequeue();

                if (current.Walkable)
                    return current;

                foreach (GridNode neighbour in _gridManager.GetNeighbours(current))
                {
                    if (visited.Add(neighbour))
                        queue.Enqueue(neighbour);
                }
            }

            return null;
        }

        private int GetDistance(GridNode a, GridNode b)
        {
            return Mathf.Abs(a.GridPosition.x - b.GridPosition.x)
                 + Mathf.Abs(a.GridPosition.y - b.GridPosition.y);
        }

        private List<Vector3> RetracePath(GridNode startNode, GridNode endNode)
        {
            List<Vector3> path = new();

            GridNode current = endNode;

            while (current != startNode)
            {
                path.Add(current.WorldPosition);
                current = current.Parent;
            }

            path.Reverse();

            return path;
        }
    }
}