using System;

namespace Queue
{
    public struct ActionTyphoon
    {
        public Action act;
        public float time;

        public ActionTyphoon(Action act, float time)
        {
            this.act = act;
            this.time = time;
        }
    }
}