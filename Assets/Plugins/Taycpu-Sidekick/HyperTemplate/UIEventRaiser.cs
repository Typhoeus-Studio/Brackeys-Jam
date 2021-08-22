using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create UIListeners")]
public class UIEventRaiser : ScriptableObject
{
    private List<IListener> listeners = new List<IListener>();

    public void Clear()
    {
        listeners.Clear();
    }

    public void RegisterListener(IListener newEvent)
    {
        if (listeners.Contains(newEvent))
            listeners.Remove(newEvent);
        listeners.Add(newEvent);
    }

    public void EventTrigger()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].RaiseEvent();
        }
    }
}

public interface IListener
{
    public void RaiseEvent();
}