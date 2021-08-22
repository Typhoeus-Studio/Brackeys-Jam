#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace PositionSetter
{
    public class PositionSetterEditor : EditorWindow
    {
        public MeshRenderer mainObj, destObj;
        private XAXIS X;

        private YAXIS Y;
        private ZAXIS Z;
        private bool mainObjBounds;
        private bool isParent;

        [MenuItem("Taycpu/Position Setter")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            PositionSetterEditor window = (PositionSetterEditor) EditorWindow.GetWindow(typeof(PositionSetterEditor));
            window.Show();
        }

        void OnGUI()
        {
            GUILayout.Label("Main Object", EditorStyles.boldLabel);
            mainObj = (MeshRenderer) EditorGUILayout.ObjectField(mainObj, typeof(MeshRenderer), true);
            GUILayout.Label("Target Object", EditorStyles.boldLabel);
            destObj = (MeshRenderer) EditorGUILayout.ObjectField(destObj, typeof(MeshRenderer), true);
            GUILayout.Label("POSITIONS", EditorStyles.boldLabel);
            X = (XAXIS) EditorGUILayout.EnumPopup("X AXIS", X);
            Y = (YAXIS) EditorGUILayout.EnumPopup("Y AXIS ", Y);
            Z = (ZAXIS) EditorGUILayout.EnumPopup("Z AXİS ", Z);
            mainObjBounds = GUILayout.Toggle(mainObjBounds, "Calculate Main Object Bounds");
            isParent = GUILayout.Toggle(isParent, "Set Parents position");
            if (mainObj != null)
            {
                GUILayout.Label("Set To Ground", EditorStyles.boldLabel);

                if (GUILayout.Button("Set To Ground"))
                {
                    PositionSetter.ConfigureAxis(X, Y, Z, mainObjBounds, isParent);
                    PositionSetter.SetToGround(mainObj);
                }
            }

            if (mainObj != null && destObj != null)
            {
                GUILayout.Label("X Axis", EditorStyles.boldLabel);

                if (GUILayout.Button("Set X Axis"))
                {
                    PositionSetter.ConfigureAxis(X, Y, Z, mainObjBounds, isParent);
                    PositionSetter.SetXAxisImmediately(mainObj, destObj, Axes.X);
                }

                GUILayout.Label("Y Axis", EditorStyles.boldLabel);

                if (GUILayout.Button("Set Y Axis"))
                {
                    PositionSetter.ConfigureAxis(X, Y, Z, mainObjBounds, isParent);
                    PositionSetter.SetYAxisImmediately(mainObj, destObj, Axes.Y);
                }

                GUILayout.Label("Z Axis", EditorStyles.boldLabel);

                if (GUILayout.Button("Set Z Axis"))
                {
                    PositionSetter.ConfigureAxis(X, Y, Z, mainObjBounds, isParent);
                    PositionSetter.SetZAxisImmediately(mainObj, destObj, Axes.Z);
                }

                GUILayout.Label("All Axes", EditorStyles.boldLabel);

                if (GUILayout.Button("Set All Axes"))
                {
                    PositionSetter.ConfigureAxis(X, Y, Z, mainObjBounds, isParent);
                    PositionSetter.SetAllAxisImmediately(mainObj, destObj, Axes.ALL);
                }
            }
        }
    }
}
#endif