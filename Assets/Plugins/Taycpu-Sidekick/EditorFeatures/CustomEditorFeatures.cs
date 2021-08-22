#if UNITY_EDITOR

using HyperTemplate.HyperMono.HyperCore;
using UnityEditor;
using UnityEngine;

namespace EditorFeatures
{
    public class CustomEditorFeatures 
    {

        [MenuItem("Taycpu/FindReferences")]
        public static void FindAllObjects()
        {
            var hyperMonos= GameObject.FindObjectsOfType<HyperMono>();

            for (int i = 0; i < hyperMonos.Length; i++)
            {
                hyperMonos[i].FindOwnReferences();
            }
        }
    }
}
#endif