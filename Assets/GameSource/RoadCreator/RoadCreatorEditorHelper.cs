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
        Debug.Log(e.keyCode);
        if (e.isKey)
        {
            if (e.keyCode == KeyCode.U)
            {
                RoadCreatorEditor.GetObject();
            }

            if (e.keyCode == KeyCode.J)
            {
                RoadMono.onGenerateMode = !RoadMono.onGenerateMode;
                RoadMono.SetToGenerateMod();
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