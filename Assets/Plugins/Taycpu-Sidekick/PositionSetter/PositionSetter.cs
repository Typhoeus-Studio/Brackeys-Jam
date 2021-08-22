using CustomFeatures;
using UnityEngine;

namespace PositionSetter
{
    public enum XAXIS
    {
        LEFT,
        RIGHT,
        CENTER,
    }

    public enum YAXIS
    {
        UNDER,
        ABOVE,
        CENTER
    }

    public enum ZAXIS
    {
        BACKWARD,
        FORWARD,
        CENTER
    }

    public enum Axes
    {
        X,
        Y,
        Z,
        ALL
    }

    public static class PositionSetter
    {
        private static XAXIS X;
        private static YAXIS Y;
        private static ZAXIS Z;
        private static bool haveOffset;
        private static bool setParent;

        public static void ConfigureAxis(XAXIS xx, YAXIS yy, ZAXIS zz, bool haveOffs, bool parent)
        {
            X = xx;
            Y = yy;
            Z = zz;
            haveOffset = haveOffs;
            setParent = parent;
        }

        private static Vector3 CalculatePlacedPosition(Vector3[] pos, MeshRenderer mainObj)
        {
            int cX = (int) X;
            int cY = (int) Y;
            int cZ = (int) Z;
            if (X == XAXIS.CENTER) cX = 0;
            if (Y == YAXIS.CENTER) cY = 0;
            if (Z == ZAXIS.CENTER) cZ = 0;
            Vector3 mainBounds = MeshFeatures.CalculateBounds(mainObj);
            Vector3 destCalculatedBounds = new Vector3(pos[cX].x, pos[cY].y, pos[cZ].z);

            Vector3 mainCalculatedBounds = Vector3.zero;
            if (haveOffset)
                mainCalculatedBounds = new Vector3(0, Y == YAXIS.ABOVE ? mainBounds.y : mainBounds.y * -1, 0);
            return destCalculatedBounds + mainCalculatedBounds;
        }

        private static Vector3 GetCenter(Vector3[] pos)
        {
            return (pos[0] + pos[1]) / 2;
        }

        private static void SetPosition(Vector3[] pos, MeshRenderer mainObj, Axes axes)
        {
            Vector3 calculatedPos = CalculatePlacedPosition(pos, mainObj);
            Vector3 finalPos = mainObj.transform.position;
            Vector3 difference = Vector3.zero;
            if (haveOffset)
                difference = mainObj.bounds.center - mainObj.transform.position;

            switch (axes)
            {
                case Axes.X:
                    finalPos.x = calculatedPos.x;
                    break;
                case Axes.Y:
                    finalPos.y = calculatedPos.y;
                    break;
                case Axes.Z:
                    finalPos.z = calculatedPos.z;
                    break;
                case Axes.ALL:
                    finalPos = calculatedPos;
                    break;
            }

            if (X == XAXIS.CENTER)
            {
                finalPos.x = GetCenter(pos).x;
            }

            if (Y == YAXIS.CENTER)
            {
                finalPos.y = GetCenter(pos).y;
            }

            if (Z == ZAXIS.CENTER)
            {
                finalPos.z = GetCenter(pos).z;
            }

            if (setParent)
            {
                mainObj.transform.parent.position = finalPos - difference;
            }
            else
            {
                mainObj.transform.position = finalPos - difference;
            }
        }


        #region Public Methods

        public static void SetAllAxisImmediately(MeshRenderer mainObjc, MeshRenderer destObjc, Axes ax)
        {
            SetPosition(MeshFeatures.CalculateBoundsWithPosition(destObjc), mainObjc, ax);
        }

        public static void SetXAxisImmediately(MeshRenderer mainObjc, MeshRenderer destObjc, Axes ax)
        {
            SetPosition(MeshFeatures.CalculateBoundsWithPosition(destObjc), mainObjc, ax);
        }

        public static void SetYAxisImmediately(MeshRenderer mainObjc, MeshRenderer destObjc, Axes ax)
        {
            SetPosition(MeshFeatures.CalculateBoundsWithPosition(destObjc), mainObjc, ax);
        }

        public static void SetZAxisImmediately(MeshRenderer mainObjc, MeshRenderer destObjc, Axes ax)
        {
            SetPosition(MeshFeatures.CalculateBoundsWithPosition(destObjc), mainObjc, ax);
        }

        public static void SetToGround(MeshRenderer mainObj)
        {
            if (Physics.Raycast(mainObj.transform.position, mainObj.transform.TransformDirection(Vector3.down),
                out var hit))
            {
                Vector3 yOffset = new Vector3(0, MeshFeatures.CalculateBounds(mainObj).y, 0);
                Debug.Log(hit.transform.name);
                if (setParent)
                {
                    mainObj.transform.parent.position = hit.point + yOffset;
                }
                else
                {
                    mainObj.transform.position = hit.point + yOffset;
                }
            }
        }

        #endregion
    }
}