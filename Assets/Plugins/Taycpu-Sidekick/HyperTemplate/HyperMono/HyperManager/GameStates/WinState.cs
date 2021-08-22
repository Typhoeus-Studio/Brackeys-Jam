using CustomFeatures.Timer;
using HyperFeatures;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperManager.GameStates
{
    public class WinState : EndState
    {
        public override void EnterState(GameManager owner)
        {
            Debug.Log("Win");
            owner.currentLevel.EndLevel(true);

            SoloTimer timer = new SoloTimer();
            timer.SetTimer(() => ScreenManager.Instance.ShowUI(2), 1.2f);
            TimerProcessor.Instance.AddTimer(timer);

        }

        public override void UpdateState(GameManager owner)
        {
        }

        public override void ExitState(GameManager owner)
        {
            owner.levelController.LevelSuccess();
            DestroyScene(owner);
        }
    }
}