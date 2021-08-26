using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Enemy> enemies;
    [SerializeField] private Player player;


    private void Start()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].Initialize(player);
        }
    }
}