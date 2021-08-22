using HyperFeatures;

namespace HyperTemplate.HyperMono.HyperManager.GameStates
{
    public class LoseState : EndState
    {
        public override void EnterState(GameManager owner)
        {
            ScreenManager.Instance.ShowUI(3);
            owner.currentLevel.EndLevel(false);
        }

        public override void UpdateState(GameManager owner)
        {
        }

        public override void ExitState(GameManager owner)
        {
            DestroyScene(owner);
        }
    }
}