using UnityEngine;

[CreateAssetMenu(menuName = "Create FloatVariableWOutEvent", fileName = "FloatVariableWOutEvent", order = 0)]
public class FloatVariableWOutEvent : ScriptableObject
{
    [SerializeField] private float _value;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }
}