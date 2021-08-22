using HyperTemplate.Datas;
using HyperTemplate.HyperMono.HyperCore;

namespace HyperTemplate.HyperMono.HyperManager
{
    public class SoundManager : HyperManager<SoundManager>
    {
        public SoundData[] soundData;

        public void PlaySound(int dataIndex, int soundIndex)
        {
            soundData[dataIndex].PlaySound(soundIndex);
        }

        public override void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}