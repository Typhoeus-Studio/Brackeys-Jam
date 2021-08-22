using System;
using UnityEngine;

namespace HyperTemplate.Datas
{
    [Serializable]
    public class SoundData
    {
        public AudioClip[] audios;
        public AudioSource source;

        public void PlaySound(int index)
        {
            source.PlayOneShot(audios[index]);
        }
    }
}