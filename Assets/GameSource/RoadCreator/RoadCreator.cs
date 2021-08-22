using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RoadCreator
{
    public static void SetToGround(Transform destObj, Renderer meshRenderer, Vector3 offset)
    {
        if (RayToGround(out var hit, destObj))
        {
            destObj.transform.position = hit.point + offset;
        }
    }

    private static bool RayToGround(out RaycastHit hit, Transform obj)
    {
        if (Physics.Raycast(obj.position, obj.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            return true;
        }

        return false;
    }

    private static Vector3 CalculateMeshHeight(Renderer meshRenderer)
    {
        Vector3 height = new Vector3();
        height.y = meshRenderer.bounds.size.y / 2f;
        return height;
    }
}