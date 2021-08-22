#if UNITY_EDITOR
using CustomFeatures;
using UnityEditor;
using UnityEngine;

namespace ModuleHandler
{
    public class ModuleCenterEditor : EditorWindow
    {
        private ModuleCenter moduleCenter;

        [MenuItem("Taycpu/Module Center")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            ModuleCenterEditor window = GetWindow<ModuleCenterEditor>();

            window.Show();
        }


        private void OnGUI()
        {
            GUILayout.Label("Main SDKs", EditorStyles.boldLabel);
            moduleCenter = (ModuleCenter) EditorGUILayout.ObjectField(moduleCenter,typeof(ModuleCenter));
            if (moduleCenter != null)
            {
                DrawToggles();
            }
               
            GUILayout.Label("Data ", EditorStyles.boldLabel);
            DrawButtons();
        }


        private void DrawToggles()
        {
           
            EditorHelpers.ToggleCreator(ref moduleCenter.isAdsActive, "Set ADS active");
            EditorHelpers.ToggleCreator(ref moduleCenter.isFirebaseActive, "Set Firebase active");
            EditorHelpers.ToggleCreator(ref moduleCenter.isAnalyticActive, "Set Analytics active");
            EditorHelpers.ToggleCreator(ref moduleCenter.isIapActive, "Set IAP active");
            EditorHelpers.ToggleCreator(ref moduleCenter.isDevMode, "Dev Mode");
        }

        private void DrawButtons()
        {
     //       EditorHelpers.ButtonCreator("Wipe All Datas", () => DataHandler.WipeAllData());
        }
    }
}
#endif