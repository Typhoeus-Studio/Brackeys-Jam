using UnityEngine;

public class PlayerBulletController : BulletController
{
    private void Update()
    {
        if (Input.GetButton("Fire1"))
            ShootDirect();

        CooldownCheck();
    }
}