using HyperTemplate.HyperMono.HyperCore;

namespace HyperTemplate.HyperMono.HyperUI
{
    public abstract class HyperUIElement : HyperMonoUIObject
    {
        public void Hide()
        {
            
            AfterHide();
        }

        protected virtual void AfterHide()
        {
        }

        public void Show()
        {
            
            AfterShow();
        }

        protected virtual void AfterShow()
        {
        }

        public override void FindOwnReferences()
        {
            throw new System.NotImplementedException();
        }
    }
}