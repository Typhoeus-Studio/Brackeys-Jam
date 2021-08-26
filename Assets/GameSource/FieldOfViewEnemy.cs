using System;
using UnityEngine;

public class FieldOfViewEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask targetMask, obstructionMask;
    public float radius;
    public float angle;
    public bool canSeePlayer;


    private void Update()
    {
        FieldOfViewCheck();
    }

    void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            CheckAngle(transform.forward, directionToTarget);
        }
    }

    void CheckAngle(Vector3 from, Vector3 to)
    {
        if (Vector3.Angle(from, to) < angle / 2f)
        {
            if (CheckObstacle(to))
            {
                Debug.Log("Player is in here");
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else
        {
            Debug.Log("Player is not in the vision");
            canSeePlayer = false;
        }
    }

    bool CheckObstacle(Vector3 dir)
    {
        if (Physics.Raycast(transform.position, dir, Mathf.Infinity, obstructionMask))
        {
            return false;
        }

        return true;
    }
}