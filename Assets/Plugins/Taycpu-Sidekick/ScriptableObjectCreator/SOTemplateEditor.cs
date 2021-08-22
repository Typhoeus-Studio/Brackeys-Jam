#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using CustomFeatures;
using UnityEditor;
using UnityEngine;


namespace ScriptableObjectCreator
{
    public class SOTemplateEditor : EditorWindow
    {
        private static List<Type> scriptableObjects = new List<Type>();

        private static List<string> soNames = new List<string>();
        private static string[] scriptables;
        private int index = 0;
        private int lastIndex;

        private static string lastName;

        private TaycpuScriptable currentScriptable;

        public int Index
        {
            get => index;
            set
            {
                index = value;

                if (index != lastIndex)
                    isCreated = false;

                lastIndex = index;
            }
        }

        private static bool isInitialized;
        private static bool isCreated;

        [MenuItem("Taycpu/SO Template Creator")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            SOTemplateEditor window = (SOTemplateEditor) EditorWindow.GetWindow(typeof(SOTemplateEditor));

            FindObject();

            window.Show();
        }

        private void OnGUI()
        {
            if (!isInitialized) return;

            if (scriptables.Length <= 0) return;
            GUILayout.Label("Main Object", EditorStyles.boldLabel);

            Index = EditorGUILayout.Popup(Index, scriptables);

            for (int s = 0; s < scriptableObjects.Count; s++)
            {
                if (scriptableObjects[s].Name == soNames[index])
                {
                    if (!isCreated)
                    {
                        TaycpuScriptable obj = (TaycpuScriptable) Activator.CreateInstance(scriptableObjects[s]);
                        var y = CreateAssetScriptable<TaycpuScriptable>(obj);
                        Type type = scriptableObjects[s];

                        dynamic converted = Convert.ChangeType(y, y.GetType());
                        
                    }

                    var fields = scriptableObjects[s].GetFields();
                    for (int i = 0; i < fields.Length; i++)
                    {
                        if (fields[i].IsPublic)
                        {
                            if (fields[i].FieldType == typeof(String))
                            {
                                currentScriptable.name =
                                    EditorGUILayout.TextField("Object Name: ", currentScriptable.name);
                            }
                            else if (fields[i].FieldType == typeof(Int32))
                            {
                            }
                        }
                    }
                }
            }

            if (GUILayout.Button("Create"))
            {
            }
        }

        public static T ConvertObject<T>(object input)
        {
            return (T) Convert.ChangeType(input, typeof(T));
        }

        private static T CreateAssetScriptable<T>(TaycpuScriptable taycpuScriptable) where T : ScriptableObject
        {
            isCreated = true;
            Debug.Log(typeof(TaycpuScriptable));
            lastName = "Assets/" + "taycpuScriptable.namex" + ".asset";
            AssetDatabase.CreateAsset(taycpuScriptable, lastName);
            AssetDatabase.SaveAssets();
            return AssetDatabase.LoadAssetAtPath<T>(lastName);
        }


        static void FindObject()
        {
            IEnumerable<Type> GetAll()
            {
                return AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(type => type.IsSubclassOf(typeof(TaycpuScriptable)));
            }

            GetAll().ToList().ForEach(x => scriptableObjects.Add(x));

            foreach (var so in scriptableObjects)
            {
                soNames.Add(so.Name);
            }

            scriptables = soNames.ToArray();

            isInitialized = true;
        }
    }

    public class CustomType<T>
    {
        public T customObj;
    }
}
#endif