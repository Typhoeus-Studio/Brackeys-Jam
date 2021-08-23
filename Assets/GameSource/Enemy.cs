using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AgentPointController pointController;
    public Guid id = new Guid();

    private void Start()
    {
        GetNew();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //Particles,Anims
        if (health <= 0)
            Die();
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.1f)
        {
            GetNew();
        }
    }


    void GetNew()
    {
        var obj=pointController.GetNewTarget(id);
        agent.SetDestination(obj.point.position);
    }

    private void Die()
    {
        //Particles etc.
    }
}