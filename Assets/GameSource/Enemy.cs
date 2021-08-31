using System;
using Pool;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    private bool isAvailable;
    public int health;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AgentPointController pointController;
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject ragdoll;


    [SerializeField] private EnemyBulletController bulletController;

    public Guid id = new Guid();

    [SerializeField] private FieldOfViewEnemy fieldOfViewEnemy;


    public void Initialize()
    {
        transform.position = pointController.GetNewTarget(id).point.position;
        isAvailable = true;
        GetNew();
    }

    public void TakeDamage(int damage)
    {
        if (!isAvailable) return;
        health -= damage;
        TWEAKS.PlayParticle(CONSTANTS.P_HIT, transform.position);
        //Particles,Anims
        if (health <= 0)
            Die();
    }

    private void Update()
    {
        if (!isAvailable) return;

        if (fieldOfViewEnemy.canSeePlayer)
        {
            if (!agent.isStopped)
                agent.isStopped = true;
            Vector3 dir = fieldOfViewEnemy.player.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
            bulletController.ShootDirect();
            bulletController.CooldownCheck();
        }
        else
        {
            if (agent.isStopped)
                agent.isStopped = false;
            if (agent.remainingDistance < 0.1f)
                GetNew();
        }
    }


    void GetNew()
    {
        var obj = pointController.GetNewTarget(id);
        agent.SetDestination(obj.point.position);
    }

    private void Die()
    {
        isAvailable = false;
        agent.isStopped = true;
        TWEAKS.PlayParticle(CONSTANTS.P_DIE, transform.position);
        model.SetActive(false);
        ragdoll.SetActive(true);
        //Particles etc.
    }
}