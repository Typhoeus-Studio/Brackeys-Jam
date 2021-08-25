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

    [SerializeField] private Player player;

    [SerializeField] private EnemyBulletController bulletController;

    public Guid id = new Guid();

    private void Initialize(Player play)
    {
        player = play;
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
        if (agent.remainingDistance < 0.1f)
        {
            GetNew();
        }

        LookForPlayer();
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


    void LookForPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 15)
        {
            transform.LookAt(player.transform.position);
            bulletController.ShootDirect();
            bulletController.CooldownCheck();
        }
    }
}

