using FiniteStateMachine.Generic;
using HyperFeatures;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperManager.GameStates
{
    public class GameState : State<GameManager>
    {
        public override void EnterState(GameManager owner)
        {
            Debug.Log("Entering the Game State");

            ScreenManager.Instance.ShowUI(1);
            owner.currentLevel.StartLevel();
        }

        public override void UpdateState(GameManager owner)
        {
            owner.currentLevel.MainUpdate();
        }

        public override void ExitState(GameManager owner)
        {
            Debug.Log("When exit the game state");
        }
    }
}