using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        //Particles,Anims
        if (health <= 0)
            Die();
    }


    private void Die()
    {
        //Particles etc.
    }
}