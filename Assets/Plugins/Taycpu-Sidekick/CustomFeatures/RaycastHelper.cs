using UnityEngine;

namespace CustomFeatures
{
    public  class RaycastHelper
    {
        #region Raycast

        public Vector3 RayToScreenVector3(Camera cam, Vector3 pos)
        {
            Ray ray = cam.ScreenPointToRay(pos);
            Physics.Raycast(ray, out var hit);
            return hit.point;
        }

        public Vector3 RayToScreenVector3(Camera cam, Vector3 pos, LayerMask layerMask)
        {
            Ray ray = cam.ScreenPointToRay(pos);
            Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask);
            return hit.point;
        }


        public RaycastHit RayToScreenHitObject(Camera cam, Vector3 pos)
        {
            Ray ray = cam.ScreenPointToRay(pos);
            Physics.Raycast(ray, out var hit);
            return hit;
        }

        public RaycastHit RayToScreenHitObject(Camera cam, Vector3 pos, LayerMask layerMask)
        {
            
            Ray ray = cam.ScreenPointToRay(pos);
            Physics.Raycast(ray, out var hit, layerMask);
            return hit;
        }
        
        
        #endregion
    }
}