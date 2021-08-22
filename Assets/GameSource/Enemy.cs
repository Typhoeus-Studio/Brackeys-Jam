using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AgentPointController pointController;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        //Particles,Anims
        if (health <= 0)
            Die();
    }

    private void Update()
    {
        if (agent.remainingDistance<0.1f)
        {
            Patrol();
        }
    }


    void Patrol()
    {
        
    }

    private void Die()
    {
        //Particles etc.
    }
}