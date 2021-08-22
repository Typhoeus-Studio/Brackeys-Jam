using System;
using DG.Tweening;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperCore
{
    public class HyperCam : HyperSelfGameObject
    {
        public Camera cam;
        public bool isOn;
        [SerializeField] public Transform target;

        public Vector3 offset;
        [SerializeField] private Vector3 defaultPos;
        [SerializeField] private Vector3 defaultRot;

        [SerializeField] private bool lockX, lockY, lockZ;
        [SerializeField] private float maxValueY;

        [SerializeField] private float speed;
        private Sequence mySequence;

        public override void FindOwnReferences()
        {
            throw new System.NotImplementedException();
        }

        public override void Initialize()
        {
            isOn = true;
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public void StopCamera()
        {
            isOn = false;
        }

        public void FinishPosition(Vector3 finishPos, Vector3 playerPos)
        {
            mySequence = DOTween.Sequence();
            isOn = false;
            mySequence.Append(transform.DOMoveY(finishPos.y, 1));
            //mySequence.Insert(0, transform.DORotate(new Vector3(24, 50, 0), 1f));
            //         mySequence.Insert(0, transform.DOLookAt(playerPos, 0.5f));
            // transform.DOMove(finishPos, 1f);
            // transform.DORotate(new Vector3(24, 179, 0), 1f);
        }

        public void Initialize(Transform target)
        {
            isOn = true;
            // this.target = target;
        }

        public void LateUpdate()
        {
            if (!isOn) return;
            Vector3 tPos = target.position;
            if (lockX)
                tPos.x = 0;
            if (lockY)
                tPos.y = 0;
            if (lockZ)
                tPos.z = 0;

            tPos += offset;
            if (maxValueY != 0)
                if (tPos.y > maxValueY)
                    tPos.y = maxValueY;
            transform.position = Vector3.MoveTowards(transform.position, tPos, speed);
        }

        public void SetToDefaultPos()
        {
            mySequence.Kill();
            transform.position = defaultPos;
            transform.rotation = Quaternion.Euler(defaultRot);
        }

        public void CloseFollow()
        {
            isOn = false;
        }
    }
}