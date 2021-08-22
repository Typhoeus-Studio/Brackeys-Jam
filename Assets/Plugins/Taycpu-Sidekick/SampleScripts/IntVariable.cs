using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Create IntVariable")]
public class IntVariable : UIEventRaiser
{
    private int count;
    public int Count => count;

    public void OnEnable()
    {
        count = 0;
    }

    public void AddCount(int amount)
    {
        count += amount;
        EventTrigger();
    }
}