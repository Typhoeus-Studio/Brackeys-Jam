using System;
using CustomFeatures;
using UnityEngine;

namespace HyperFeatures
{
    [CreateAssetMenu(fileName = "Runner Movement")]
    public class RunnerMovementHelper : ScriptableObject
    {
        public float minXClamp, maxXClamp, speed, sensitivity, lookLerp, xOffSet, zOffset;

        private Vector3 lastPos, lookPos;

        private bool lookLeftFlag, lookRightFlag, lookForwardFlag, lookTimerFlag;

        private float lookTime = 0.1f, lookCurTimer;
        [SerializeField] private float sensitivityDelta;
        [SerializeField] private float lookOffsetX;
        [SerializeField] private float xTimer;

        private bool canRun;

        public void RunnerMovement(Transform playerPos, Vector3 deltaPos)
        {
            Vector3 tPos = playerPos.position;
            float xVal = Mathf.Clamp(tPos.x + (deltaPos.x * (sensitivity * Time.deltaTime)), minXClamp, maxXClamp);
            tPos.x = Mathf.MoveTowards(tPos.x, xVal, sensitivityDelta);
            tPos.z += (speed * Time.deltaTime);


            if (lastPos.x - lookOffsetX > tPos.x)
            {
                lookCurTimer = lookTime;
                lookLeftFlag = true;
                lookRightFlag = false;
            }
            else if (lastPos.x + lookOffsetX < tPos.x)
            {
                lookCurTimer = lookTime;
                lookRightFlag = true;
                lookLeftFlag = false;
            }

            if (lookLeftFlag)
            {
                lookPos.x = Mathf.Lerp(lookPos.x, -xOffSet, lookLerp * Time.deltaTime);
                if (Mathf.Abs(lookPos.x - (-xOffSet)) < 0.1f)
                {
                    lookTimerFlag = true;
                }
            }
            else if (lookRightFlag)
            {
                lookPos.x = Mathf.Lerp(lookPos.x, xOffSet, lookLerp * Time.deltaTime);
                if (Mathf.Abs(lookPos.x - (xOffSet)) < 0.1f)
                {
                    lookTimerFlag = true;
                }
            }

            else if (lookForwardFlag)
            {
                lookPos.x = Mathf.Lerp(lookPos.x, 0, (lookLerp * 1.2f) * Time.deltaTime);
                if (Mathf.Abs(lookPos.x - 0) < 0.1f)
                {
                    lookForwardFlag = false;
                }
            }

            if (lookTimerFlag)
            {
                lookCurTimer -= Time.deltaTime;
                if (lookCurTimer <= 0)
                {
                    lookLeftFlag = false;
                    lookRightFlag = false;
                    lookForwardFlag = true;
                    lookTimerFlag = false;
                }
            }

            lookPos.z = zOffset;
            playerPos.rotation = Quaternion.LookRotation(lookPos);
            playerPos.position = tPos;
            lastPos = tPos;
        }

        public void RunnerMovementRigidbody(Rigidbody playerPos, Vector3 deltaPos)
        {
            if (Vector3.Distance(deltaPos, Vector3.zero) < 0.1f)
                ResetFlags(); //Maybe put this on OnMouseUp EVent
            Vector3 tPos = playerPos.position;
            float xVal = Mathf.Clamp(tPos.x + (deltaPos.x * (sensitivity * Time.deltaTime)), minXClamp, maxXClamp);

            tPos.x = xVal;
            tPos.z += (speed * Time.deltaTime);


            if (lastPos.x - lookOffsetX > tPos.x)
            {
                lookCurTimer = lookTime;
                lookLeftFlag = true;
                lookRightFlag = false;
            }
            else if (lastPos.x + lookOffsetX < tPos.x)
            {
                lookCurTimer = lookTime;
                lookRightFlag = true;
                lookLeftFlag = false;
            }

            if (lookLeftFlag)
            {
                lookPos.x = Mathf.SmoothStep(lookPos.x, -xOffSet, lookLerp * Time.deltaTime);
                if (Mathf.Abs(lookPos.x - (-xOffSet)) < 0.1f)
                {
                    lookTimerFlag = true;
                }
            }
            else if (lookRightFlag)
            {
                lookPos.x = Mathf.SmoothStep(lookPos.x, xOffSet, lookLerp * Time.deltaTime);
                if (Mathf.Abs(lookPos.x - (xOffSet)) < 0.1f)
                {
                    lookTimerFlag = true;
                }
            }

            else if (lookForwardFlag)
            {
                lookPos.x = Mathf.SmoothStep(lookPos.x, 0, (lookLerp * 2) * Time.deltaTime);
                if (Mathf.Abs(lookPos.x - 0) < 0.1f)
                {
                    lookForwardFlag = false;
                }
            }

            if (lookTimerFlag)
            {
                lookCurTimer -= Time.deltaTime;
                if (lookCurTimer <= 0)
                    ResetFlags();
            }

            lookPos.z = zOffset;
            //  playerPos.rotation = Quaternion.LookRotation(lookPos);
            playerPos.MoveRotation(Quaternion.LookRotation(lookPos));
            playerPos.MovePosition(tPos);
            lastPos = tPos;
        }

        private void ResetFlags()
        {
            lookLeftFlag = false;
            lookRightFlag = false;
            lookForwardFlag = true;
            lookTimerFlag = false;
        }

        public void Jump(Rigidbody rb, Vector3 pos, float jumpTime)
        {
            canRun = false;
            rb.AddForce(ParabolaShoot.BallisticVelocity(rb.position, pos, jumpTime), ForceMode.VelocityChange);
        }

        public void DropFromJump()
        {
            canRun = true;
        }

        public void LoadDefaultValues()
        {
            minXClamp = -1;
            maxXClamp = 1f;
            speed = 4;
            sensitivity = 200;
            lookLerp = 10;
            xOffSet = 1;
            zOffset = 3;
            sensitivityDelta = 0.3f;
            lookOffsetX = 0.05f;
            xTimer = 0.3f;
        }
    }
}