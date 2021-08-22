using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

namespace CustomFeatures
{

    public class MyCollection
    {
        private Random random = new Random();

        public IEnumerable<int> GetRandomNumber(int count)
        {
            for (int c = 0; c < count; c++)
            {
                yield return random.Next();
            }
        }
    }

    public class MyCustomNumeratorTest
    {


        public void TestCor()
        {
            IEnumerator cor = MyCoroutine();
            
            
        }
        

        public IEnumerator MyCoroutine()
        {
            
            yield return null;

        }
    }
}