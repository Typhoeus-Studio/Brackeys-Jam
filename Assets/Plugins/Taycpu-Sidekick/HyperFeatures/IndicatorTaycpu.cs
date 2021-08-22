using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using HyperTemplate.HyperMono.HyperUI;
using UnityEngine;
using UnityEngine.UI;

namespace HyperFeatures
{
    public class IndicatorTaycpu : MonoBehaviour
    {
        [SerializeField] private RectTransform rect;

        [SerializeField] Camera camera;
        [SerializeField] Canvas canvas;
        [SerializeField] Transform followTarget;
        [SerializeField] Vector3 followOffset;

        public void Initialize(Transform target)
        {
            followTarget = target;
        }


        public void SetPos(Vector3 target)
        {
            rect.anchoredPosition = WorldToScreenPoint(camera, canvas, target + followOffset);
        }

        public void Hide()
        {
            transform.DOScale(0, 0.5f);
        }

        public static Vector2 WorldToScreenPoint(Camera camera, Canvas canvas, Vector3 targetPos)
        {
            Vector2 myPositionOnScreen = camera.WorldToScreenPoint(targetPos);
            float scaleFactor = canvas.scaleFactor;
            return new Vector2(myPositionOnScreen.x / scaleFactor, myPositionOnScreen.y / scaleFactor);
        }

        public static Vector3 WorldToScreenSpace(Vector3 worldPos, Camera cam, RectTransform area)
        {
            Vector3 screenPoint = cam.WorldToScreenPoint(worldPos);
            screenPoint.z = 0;

            Vector2 screenPos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(area, screenPoint, cam, out screenPos))
            {
                return screenPos;
            }

            return screenPoint;
        }
    }
}