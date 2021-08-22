using UnityEngine;

namespace CustomFeatures
{
    public static class MeshFeatures
    {
        public static Vector3 CalculateBounds(MeshRenderer mesh)
        {
            Vector3 size = mesh.bounds.size;


            Vector3 last = size / 2f;

            return last;
        }

        public static Vector3[] CalculateBoundsWithPosition(MeshRenderer mesh)
        {
            var bounds1 = mesh.bounds;
            Vector3 min = bounds1.min;
            Vector3 max = bounds1.max;

            Vector3[] bounds = new Vector3[]
            {
                min,
                max
            };
            return bounds;
        }

        public static bool CheckBounds(Transform cur, Vector3[] bounds, Vector3 offset)
        {
            float xMinBound = bounds[0].x + offset.x;
            float xMaxBound = bounds[1].x - offset.x;
            float yMinBound = bounds[0].y + offset.y;
            float yMaxBound = bounds[1].y - offset.y;
            float zMinBound = bounds[0].z + offset.z;
            float zMaxBound = bounds[1].z - offset.z;

            bool xCheck = cur.position.x < xMinBound || cur.position.x > xMaxBound;
            bool yCheck = cur.position.y < yMinBound || cur.position.y > yMaxBound;
            bool zCheck = cur.position.z < zMinBound || cur.position.z > zMaxBound;
            return xCheck || yCheck || zCheck;
        }
    }
}