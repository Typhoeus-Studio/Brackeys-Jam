using Pool;
using UnityEngine;

public static class TWEAKS
{
    public static void PlayParticle(int index, Vector3 pos)
    {
        ParticleSystem particle = ParticlePool.Instance.GetFromPool(index);
        particle.transform.position = pos;
        particle.Play();
    }
}