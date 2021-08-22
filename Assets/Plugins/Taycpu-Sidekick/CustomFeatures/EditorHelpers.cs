using System;
using UnityEngine;

namespace CustomFeatures
{
    public static class EditorHelpers
    {
        public static void ButtonCreator(string label, Action act)
        {
            if (GUILayout.Button(label))
            {
                act?.Invoke();
            }
        }
     
        public static void ToggleCreator(ref bool param, string label)
        {
            param = GUILayout.Toggle(param, label);
        }
    }
}