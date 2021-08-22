using System;
using UnityEngine;

namespace CustomFeatures
{
    [CreateAssetMenu(fileName = "Touch Helper")]
    public class TouchHelper : ScriptableObject
    {
        private Vector3 startPos, deltaPos;
        public Action<Vector3> OnRelease;


        public Vector3 CheckForInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                //Debug.Log("MOUSE POS = "+Input.mousePosition+"start pos = "+startPos);
                deltaPos = Input.mousePosition - startPos;
            }

            if (Input.GetMouseButtonUp(0))
            {

                OnRelease(deltaPos);
                deltaPos = Vector3.zero;
            }

            deltaPos.x = deltaPos.x / Screen.width;
            deltaPos.y = deltaPos.y / Screen.height;
            return deltaPos;
        }
    }
}