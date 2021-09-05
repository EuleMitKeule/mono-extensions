using UnityEngine;

namespace UnityExtensions.Runtime
{
    public static class Vector2IntExtensions
    {
        /// <summary>
        /// Converts a cell position to the cell's center point in world space
        /// </summary>
        /// <param name="cellPosition"></param>
        /// <returns></returns>
        public static Vector2 ToWorld(this Vector2Int cellPosition) => cellPosition + Vector2.one * 0.5f;

        public static bool IsInBounds(this Vector2Int cell, Vector2Int bounds) =>
            cell.x >= -bounds.x / 2 && cell.x < bounds.x / 2 &&
            cell.y >= -bounds.y / 2 && cell.y < bounds.y / 2;

        public static bool IsInBounds(this Vector2Int cell, Vector3Int bounds) =>
            cell.IsInBounds((Vector2Int) bounds);
    }
}