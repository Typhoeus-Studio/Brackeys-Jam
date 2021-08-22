using FiniteStateMachine.Generic;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperManager.GameStates
{
    public class IdleState : State<GameManager>
    {
        public override void EnterState(GameManager owner)
        {
            LoadLevel(owner);
            ScreenManager.Instance.ShowUI(0);
        }

        public override void UpdateState(GameManager owner)
        {
        }

        public override void ExitState(GameManager owner)
        {
        }

        protected void LoadLevel(GameManager owner)
        {
            owner.currentLevel = GameObject.Instantiate(owner.levelController.GetLevel());
            owner.currentLevel.gameObject.SetActive(true);
            owner.currentLevel.Load(owner.levelData);
        }
    }
}