using System;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(RoadMono))]
public class RoadCreatorEditorHelper : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RoadMono.offset = (Vector3) EditorGUILayout.Vector3Field("Offset", RoadMono.offset);
    }

    void OnSceneGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            if (e.keyCode == KeyCode.K)
            {
                RoadMono.SetObjectToTheGround();
            }

            if (e.keyCode == KeyCode.J)
            {
                RoadMono.onGenerateMode = true;
                Debug.Log("ON GENERATE MODE =" + RoadMono.onGenerateMode);
                RoadMono.SetToGenerateMod();
            }

            if (e.keyCode == KeyCode.L)
            {
                RoadMono.onGenerateMode = false;
            }

            if (e.keyCode == KeyCode.M)
            {
                if (!RoadMono.onGenerateMode) return;
                Debug.Log("Generating");
                RoadMono.Generate(e.mousePosition);
            }
        }


        if (RoadMono.onGenerateMode)
        {
            if (e.isKey)
            {
                if (e.keyCode == KeyCode.P)
                {
                }
            }
        }
    }
}