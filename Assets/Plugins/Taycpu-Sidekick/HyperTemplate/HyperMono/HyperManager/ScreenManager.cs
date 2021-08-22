using HyperTemplate.HyperMono.HyperCore;
using HyperTemplate.HyperMono.HyperUI;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperManager
{
    public class ScreenManager : HyperManager<ScreenManager>
    {
        [SerializeField] private HyperUIPage[] screens;

        [SerializeField] private TextUIObject[] seperateUIObjects;
        [SerializeField] private ImgUIObject[] seperateimgs;



        public void ShowUI(int index)
        {

            for (int i = 0; i < screens.Length; i++)
            {
                if (i != index)
                    screens[i].Hide();
            }

            screens[index].Show();
        }

        public void HideUI(int index)
        {
            screens[index].Hide();
        }

        public override void Initialize()
        {
            for (int i = 0; i < screens.Length; i++)
            {
                screens[i].Initialize();
            }

            for (int i = 0; i < seperateUIObjects.Length; i++)
            {
                seperateUIObjects[i].Initialize();
            }

            for (int i = 0; i < seperateimgs.Length; i++)
            {
                seperateimgs[i].Initialize();
            }
        }
    }
}