using FiniteStateMachine.Generic;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperManager.GameStates
{
    public class EndState : State<GameManager>
    {
        public override void EnterState(GameManager owner)
        {
        }

        public override void UpdateState(GameManager owner)
        {
        }

        public override void ExitState(GameManager owner)
        {
  
            DestroyScene(owner);
        }

        protected void DestroyScene(GameManager owner)
        {
            owner.levelController.DestroyLevel(owner.currentLevel);
            GameObject.Destroy(owner.currentLevel.gameObject);
            Debug.Log("LoseExitState");
        }
    }
}