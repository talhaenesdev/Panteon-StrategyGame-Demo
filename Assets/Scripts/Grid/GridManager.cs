using PanteonStrategyGame.Buildings.Data;
using PanteonStrategyGame.Buildings.Models;
using UnityEngine;

namespace PanteonStrategyGame.Grid
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private int width = 20;
        [SerializeField] private int height = 20;
        [SerializeField] private float cellSize = 1f;

        private GridCell[,] _cells;

        private void Awake()
        {
            CreateGrid();
        }

        private void CreateGrid()
        {
            _cells = new GridCell[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _cells[x, y] = new GridCell(new Vector2Int(x, y));
                }
            }
        }

        public bool IsInsideGrid(Vector2Int position)
        {
            return position.x >= 0 &&
                   position.x < width &&
                   position.y >= 0 &&
                   position.y < height;
        }

        public GridCell GetCell(Vector2Int position)
        {
            if (!IsInsideGrid(position))
                return null;

            return _cells[position.x, position.y];
        }

        public Vector3 GetWorldPosition(Vector2Int gridPosition)
        {
            return new Vector3(
                gridPosition.x * cellSize,
                gridPosition.y * cellSize,
                0f);
        }

        public Vector2Int GetGridPosition(Vector3 worldPosition)
        {
            return new Vector2Int(
                Mathf.RoundToInt(worldPosition.x / cellSize),
                Mathf.RoundToInt(worldPosition.y / cellSize));
        }
        public bool CanPlaceBuilding(BuildingData data, Vector2Int origin)
        {
            for (int x = 0; x < data.Size.x; x++)
            {
                for (int y = 0; y < data.Size.y; y++)
                {
                    Vector2Int position = origin + new Vector2Int(x, y);

                    if (!IsInsideGrid(position))
                        return false;

                    if (GetCell(position).IsOccupied)
                        return false;
                }
            }

            return true;
        }
        public void PlaceBuilding(Building building, BuildingData data, Vector2Int origin)
        {
            for (int x = 0; x < data.Size.x; x++)
            {
                for (int y = 0; y < data.Size.y; y++)
                {
                    Vector2Int position = origin + new Vector2Int(x, y);

                    GetCell(position).Occupy(building);
                }
            }
        }
    }
}