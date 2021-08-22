using System.Collections;
using CustomFeatures;

namespace Queue
{
    public class CoroutineProcessor : TaycpuSingleton<CoroutineProcessor>
    {
        public void AddCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine);
        }
    }
}