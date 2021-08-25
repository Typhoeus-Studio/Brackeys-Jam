using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Transform gunPos;
    [SerializeField] private float bulletForce;

    [SerializeField] private float cooldown;
    [SerializeField] private Animator animator;

    private float cdTimer;
    private bool canShoot;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (canShoot)
            {
                Fire();
                cdTimer = cooldown;
                canShoot = false;
            }
        }

        if (!canShoot)
        {
            cdTimer -= Time.deltaTime;
            if (cdTimer <= 0)
            {
                canShoot = true;
            }
        }
    }

    private void Fire()
    {
        Bullet bullet = BulletPool.Instance.GetFromPool(0);
        TWEAKS.PlayParticle(CONSTANTS.P_BULLET_EXP, gunPos.position + gunPos.forward);
        bullet.transform.rotation = transform.rotation;
        bullet.Initialize(gunPos, bulletForce);
        
        animator.Play("recoil");
        //Bullet initialize anim.
        //Shoot particle
        //Shoot anim
    }
}