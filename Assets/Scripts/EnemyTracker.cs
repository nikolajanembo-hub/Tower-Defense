using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTracker", menuName = "Scriptable Objects/EnemyTracker")]
public class EnemyTracker : ScriptableObject
{
    public event Action EnemyCountChanged;
    private List<Enemy> enemies = new List<Enemy>();
    
    public List<Enemy> Enemies => enemies;

    public void Init()
    {
        enemies = new List<Enemy>();
    }
    public void AddEnemy(Enemy enemy)
    {
        if (enemies.Contains(enemy))
        {
            return;
        }
        enemies.Add(enemy);
        EnemyCountChanged?.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (enemies.Remove(enemy))
        {
            EnemyCountChanged?.Invoke();
        }
    }
}
