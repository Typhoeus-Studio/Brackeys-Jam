using UnityEngine;

namespace ModuleHandler
{
    
    [CreateAssetMenu(menuName="Taycpu/ModuleCenter")]
    public partial class ModuleCenter : ScriptableObject
    {


        public bool isAdsActive;
        public bool isAnalyticActive;
        public bool isFirebaseActive;
        public bool isIapActive;
        public bool isDevMode;


        static partial void InitAds();
        static partial void InitAnalytics();
        static partial void InitFirebase();
        static partial void InitIap();

        
        public void RunModules()
        {
            if (isAdsActive) InitAds();
            if (isAnalyticActive) InitAnalytics();
            if (isFirebaseActive) InitFirebase();
            if (isIapActive) InitIap();
        }
    }
}