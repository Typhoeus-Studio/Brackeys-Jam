using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class AgentPoint
{
    public Transform point;
    public List<int> registeredBots = new List<int>();
}

public class AgentPointController : MonoBehaviour
{
    public List<AgentPoint> agentPoints;
    
    
}