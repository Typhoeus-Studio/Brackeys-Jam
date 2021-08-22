using System;
using System.Collections;
using System.Collections.Generic;
using CustomFeatures;
using UnityEditor;
using UnityEngine;

public class RoadCreatorEditor : EditorWindow
{
    public static Transform selectedObject;
    public static Vector3 offset;

    [MenuItem("Taycpu/Basic Road Editor")]
    static void Init()
    {
        RoadCreatorEditor window = (RoadCreatorEditor) EditorWindow.GetWindow(typeof(RoadCreatorEditor));
        window.Show();
    }


    public static void GetObject()
    {
        if (GetSelectedObject(out var ts))
        {
            selectedObject = ts;
            SetGround(ts);
        }
    }

    private static void SetGround(Transform ts)
    {
        if (ts.HasComponent<Renderer>())
            RoadCreator.SetToGround(ts, ts.GetComponent<Renderer>(), offset);
    }

    private void OnGUI()
    {
        GUILayout.Label("Main Object", EditorStyles.boldLabel);
        selectedObject = (Transform) EditorGUILayout.ObjectField(selectedObject, typeof(Transform), true);
        GUILayout.Label("Offset", EditorStyles.boldLabel);
        offset = (Vector3) EditorGUILayout.Vector3Field("Offset", offset);
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
}