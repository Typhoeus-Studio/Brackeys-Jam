using UnityEngine;

namespace CustomFeatures
{
    public class MovementHelper
    {
        public void MoveWithTowards(Transform actor, Vector3 pos, float speed = 50f)
        {
            actor.position = Vector3.MoveTowards(actor.position, pos, speed * Time.deltaTime);
        }

        public void MoveWithLerp(Transform actor, Vector3 pos, float speed = 10f)
        {
            actor.position = Vector3.Lerp(actor.position, pos, speed * Time.deltaTime);
        }

        public void MoveDirect(Transform actor, Vector3 pos)
        {
            actor.position = pos;
        }

        public void MoveToForward(Transform actor, float speed = 50f)
        {
            actor.position += actor.forward * (speed * Time.deltaTime);
        }

        public void MoveToSides(Transform actor, float speed = 50f)
        {
            actor.position += actor.right * (speed * Time.deltaTime);
        }
    }
}