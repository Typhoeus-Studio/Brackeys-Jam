using System;

[Serializable]
public abstract class TDFeedback
{
    public bool haveDelay;

    public float delay;

    public virtual void Play()
    {
    }

    public virtual void Play(object[] parameter)
    {
    }
}