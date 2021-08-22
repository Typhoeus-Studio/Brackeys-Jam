#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MaterialCreator
{
    public class MaterialCreatorEditor : EditorWindow
    {
        private Texture2D texture;
        private Material exampleMaterial;
        private string currentTextureName;

        private Object[] currentObjects;
        private HashSet<Texture2D> currentTextures = new HashSet<Texture2D>();

        private string folderName;

        [MenuItem("Taycpu/Material Generator")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            MaterialCreatorEditor window =
                (MaterialCreatorEditor) EditorWindow.GetWindow(typeof(MaterialCreatorEditor));
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Main Object", EditorStyles.boldLabel);

            if (Selection.objects != null)
            {
                if (currentObjects != null)
                    if (currentObjects.Equals(Selection.objects))
                        return;

                currentTextures.Clear();
                currentObjects = Selection.objects;


                for (int i = 0; i < currentObjects.Length; i++)
                {
                    if (currentObjects[i] is Texture2D)
                    {
                        currentTextures.Add((Texture2D) currentObjects[i]);
                        Debug.Log("Texture added");
                    }
                }
            }

            if (Selection.activeObject is Texture2D)
            {
                texture = (Texture2D) Selection.activeObject;
                currentTextureName = Selection.activeObject.name;
            }

            EditorGUILayout.ObjectField(texture, typeof(Texture), true);
            GUILayout.Label("Example Material");
            //      if (exampleMaterial == null)
//            exampleMaterial = (Material) AssetDatabase.LoadMainAssetAtPath("Assets/TyphoonSidekick/Resources");

            exampleMaterial = (Material) EditorGUILayout.ObjectField(exampleMaterial, typeof(Material), true);

            folderName = EditorGUILayout.TextField(folderName);
            if (GUILayout.Button("Create Material"))
            {
                foreach (var text in currentTextures)
                {
                    CreateMaterial(text, folderName, text.name);
                }
            }
        }


        public void CreateMaterial(Texture2D texture2D, string folderNm, string textureName)
        {
            Material mat = new Material(exampleMaterial);
            mat.mainTexture = texture2D;
            if (!AssetDatabase.IsValidFolder($"Assets/GeneratedMats/{folderNm}"))
                AssetDatabase.CreateFolder("Assets/GeneratedMats", folderNm);
            AssetDatabase.CreateAsset(mat, $"Assets/GeneratedMats/{folderNm}/{textureName}.mat");

            AssetDatabase.SaveAssets();
        }
    }
}
#endif