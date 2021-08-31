using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;

public class EnemyPool :  GenericPool<Enemy,EnemyPool>
{
    [ContextMenu("Get Childs")]
    public void GetChildsImmediaetly()
    {
        GetChilds();
    }
}
