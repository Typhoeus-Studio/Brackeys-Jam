#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace HyperFeatures
{
    [CustomEditor(typeof(RunnerMovementHelper))]
    public class RunnerMovementEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Set defaults"))
            {
                RunnerMovementHelper rm = target as RunnerMovementHelper;

                rm.LoadDefaultValues();
            }
        }
    }
}

#endif