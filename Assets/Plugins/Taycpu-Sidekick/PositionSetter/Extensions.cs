using System;
using UnityEngine;

namespace PositionSetter
{
    public static class Extensions
    {
        public static int Round(this int i, int nearest)
        {
            if (nearest <= 0 || nearest % 10 != 0)
                throw new ArgumentOutOfRangeException("nearest", "Must round to a positive multiple of 10");

            return (i + 5 * nearest / 10) / nearest * nearest;
        }

        public static float Round(this float i, float nearest)
        {
            if (nearest <= 0 || nearest % 10 != 0)
                throw new ArgumentOutOfRangeException("nearest", "Must round to a positive multiple of 10");

            return (i + 5f * nearest / 10f) / nearest * nearest;
        }



    }
}