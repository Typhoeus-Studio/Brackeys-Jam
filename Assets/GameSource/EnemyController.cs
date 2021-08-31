using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Enemy> enemies;
    [SerializeField] private Player player;


    private void Start()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].Initialize();
        }
    }

    private void GetFromPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Enemy enemy = EnemyPool.Instance.GetFromPool(0);
            enemy.Initialize();
        }
    }
}