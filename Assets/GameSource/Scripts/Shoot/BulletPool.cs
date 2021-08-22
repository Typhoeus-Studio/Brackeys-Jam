using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;

public class BulletPool : GenericPool<Bullet, BulletPool>
{
    [ContextMenu("Get Childs")]
    public void GetChildsImmediaetly()
    {
        GetChilds();
    }
}