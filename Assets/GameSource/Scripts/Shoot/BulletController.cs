using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Transform gunPos;
    [SerializeField] private float bulletForce;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Bullet bullet = BulletPool.Instance.GetFromPool(0);
        bullet.Initialize(gunPos, bulletForce);
        //Bullet initialize anim.
        //Shoot particle
        //Shoot anim
    }
}