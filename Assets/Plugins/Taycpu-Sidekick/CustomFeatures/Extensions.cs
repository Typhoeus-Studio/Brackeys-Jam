using UnityEngine;

namespace CustomFeatures
{
    public static class Extensions
    {
        #region Components

        public static bool HasComponent<T>(this Component comp)
        {
            return comp.GetComponent<T>() != null;
        }

        public static bool HasComponent<T>(this Collision comp)
        {
            return comp.gameObject.GetComponent<T>() != null;
        }

        #endregion

        public static void Dlog(this string text)
        {
            Debug.Log(text);
        }


        #region Vector3

        #endregion

        #region Vector2

        public static bool CheckForAnyInput(this Vector2 input)
        {
            return input.x.CheckOneInputAxis() || input.y.CheckOneInputAxis();
        }

        #endregion

        #region Float

        public static bool CheckOneInputAxis(this float inp)
        {
            return inp > 0 || inp < 0;
        }

        #endregion

        #region Int

        public static int ReturnToZeroAtMax(this int num, int max)
        {
            if (num >= max) num = 0;
            return num;
        }

        #endregion


        #region Bool

        #endregion
    }
}