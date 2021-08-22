using CustomFeatures.Timer;
using DG.Tweening;
using HyperTemplate.Datas;
using HyperTemplate.HyperMono.HyperCore;
using HyperTemplate.HyperMono.HyperManager;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperGameObject
{
    public class HyperPlayer : HyperCentralObject
    {
        public Vector3 finishPos;
        protected bool canRun;
        [SerializeField] protected Animator animator;
        [SerializeField] protected AnimationMediator aMediator;
        [SerializeField] protected Rigidbody rb;
        [SerializeField] protected Transform charModel;

        public override void FindOwnReferences()
        {
            throw new System.NotImplementedException();
        }

        public virtual void ReadyForStart()
        {
            transform.rotation = Quaternion.identity;
            charModel.transform.rotation = Quaternion.identity;
            Debug.Log("Ready to start");
            isAvailable = true;
        }

        public virtual void StartLevel()
        {
            canRun = true;
        }

        public override void Initialize()
        {
            isAvailable = true;
        }

        public override void Tick()
        {
        }

        public void Die()
        {
            if (!isAvailable) return;
            Debug.Log("Die");
            isAvailable = false;
            TimerProcessor.Instance.AddTimer(1.5f, () => GameManager.Instance.ChangeState(3));
            AfterDie();
        }

        protected virtual void AfterDie()
        {
        }

        public void Win()
        {
            if (!isAvailable) return;
            canRun = false;
            AfterWin();
            isAvailable = false;
            SoloTimer timer = new SoloTimer();
            timer.SetTimer(() => GameManager.Instance.ChangeState(2), 1f);
            TimerProcessor.Instance.AddTimer(timer);
        }

        public virtual void AfterWin()
        {
        }

        public void EndLevel(bool isWin)
        {
            canRun = false;
            if (isWin)
            {
                // animator.Play(aMediator.dance);
            }
            else
            {
                //animator.Play(aMediator.cry);
            }
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}