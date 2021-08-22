using DG.Tweening;
using UnityEngine;

namespace HyperFeatures
{
    public class UpAndDownAnim : MonoBehaviour
    {
        [SerializeField] private float height, time;

        private void Start()
        {
            transform.DOMoveY(transform.position.y + height, time).SetLoops(-1,LoopType.Yoyo);
        }
    }
}