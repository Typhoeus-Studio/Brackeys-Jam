using CustomFeatures;
using UnityEditor;
using UnityEngine;

public class RoadMono : MonoBehaviour
{
    public static Transform selectedObject;
    public static Vector3 offset;

    public static bool onGenerateMode;

    public static void SetObjectToTheGround()
    {
        if (GetSelectedObject(out var ts))
        {
            selectedObject = ts;
            SetGround(selectedObject);
        }
    }

    private static void SetGround(Transform ts)
    {
        if (ts.HasComponent<Renderer>())
            RoadCreator.SetToGround(ts, ts.GetComponent<Renderer>(), offset);
    }

    private static bool GetSelectedObject(out Transform transform)
    {
        transform = null;
        var obj = Selection.activeObject;
        if (obj is GameObject)
        {
            GameObject newObj = obj as GameObject;
            transform = newObj.transform;
            return true;
        }

        return false;
    }


    public static void SetToGenerateMod()
    {
        if (GetSelectedObject(out var ts))
        {
            selectedObject = ts;
        }
    }

    public static void InstantiateSelectedObject()
    {
    }
}