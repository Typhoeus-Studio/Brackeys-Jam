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
            Debug.Log(ts.name);
        }
    }

    public static void InstantiateSelectedObject()
    {
    }

    public static void Generate(Vector3 input)
    {
        var g = PrefabUtility.InstantiatePrefab(FindInProject()) as GameObject;
        g.transform.position = Camera.main.ScreenToWorldPoint(input);
    }

    private static GameObject FindInProject()
    {
        //AssetDatabase.TryGetGUIDAndLocalFileIdentifier(instanceID, out string guid, out long localId);
        string[] strs = AssetDatabase.FindAssets(selectedObject.name);
        Debug.Log(strs[0]);
        string path = AssetDatabase.GUIDToAssetPath(strs[0]);
        var obj = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject;
        return obj;
    }
}