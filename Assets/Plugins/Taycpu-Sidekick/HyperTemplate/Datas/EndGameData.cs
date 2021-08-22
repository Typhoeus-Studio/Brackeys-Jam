using System.Collections.Generic;

namespace HyperTemplate.Datas
{
    public class StringData
    {
        public List<string> keys = new List<string>();
    }

    public class EndGameData
    {
        public StringData stringData = new StringData();

        public EndGameData AddStats(string stat)
        {
            stringData.keys.Add(stat);
            return this;
        }

        public void ClearStats()
        {
            stringData.keys.Clear();
        }
    }
}