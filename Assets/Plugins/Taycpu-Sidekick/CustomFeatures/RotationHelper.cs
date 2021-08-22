using UnityEngine;

namespace CustomFeatures
{
    public class RotationHelper
    {
        public void RotateWithAnalog(Transform transform, float degree)
        {
            transform.Rotate(new Vector3(0, degree, 0) * (10 * Time.deltaTime));
        }
    }
}