using UnityEngine;

namespace HyperTemplate.HyperMono.HyperManager
{
    public class ScreenAdapter : MonoBehaviour
    {
        [SerializeField] private LevelController levelController;

        public void NextLevel()
        {
            GameManager.Instance.ChangeState(1);
        }

        public void Restart()
        {
            GameManager.Instance.ChangeState(2);
        }

        public void MainMenu()
        {
            GameManager.Instance.ChangeState(0);

        }
    }
}