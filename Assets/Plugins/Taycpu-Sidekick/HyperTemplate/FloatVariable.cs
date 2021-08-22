using UnityEngine;

[CreateAssetMenu(menuName = "Create FloatVariable", fileName = "FloatVariable", order = 0)]
public class FloatVariable : UIEventRaiser
{
    [SerializeField] private int _value;

    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;
            EventTrigger();
        }
    }
}