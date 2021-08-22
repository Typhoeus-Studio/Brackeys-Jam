using HyperFeatures;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Create LevelVariable")]
public class LevelVariable : UIEventRaiser
{
    public int GetLevel()
    {
        return PlayerPrefsHandler.GetLevel();
    }

    public void SetLevel(int amount)
    {
        PlayerPrefsHandler.UpdateLevel(amount);
        EventTrigger();
    }
}