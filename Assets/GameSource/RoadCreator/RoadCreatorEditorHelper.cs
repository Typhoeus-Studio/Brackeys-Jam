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