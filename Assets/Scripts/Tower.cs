using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : Selectable
{
    [SerializeField] private string towerName;
    private Enemy enemy;
    private List<Enemy> enemiesInRange = new List<Enemy>();
    [SerializeField] private TowerStats stats;
    [SerializeField] private Projectile projectile;
    [SerializeField] Vector3 spawnOffset;
    [SerializeField] private SphereCollider rangeCollider;
    private float time;
    private int level = 0;
    

    public int Price => stats.GetStat(level).cost;
    public int Level => level;
    public TowerStats Stats => stats;
    public string Name => towerName;

    private void Awake()
    {
        level = 0;
        rangeCollider.radius = stats.GetStat(level).range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy newenemy))
        {
            if (!enemiesInRange.Contains(newenemy))
            {
                enemiesInRange.Add(newenemy);
            }

            if (enemy == null)
            {
                enemy= newenemy;
            } ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy newenemy))
        {
            if (enemiesInRange.Contains(newenemy))
            {
                enemiesInRange.Remove(newenemy);
            }

            if (enemy == newenemy)
            {
                if (enemiesInRange.Count == 0)
                {
                    enemy = null;
                }
                else
                {
                    enemy = enemiesInRange[0];
                }
            } ;
        }
    }

    private void Update()
    {
        if (Time.time >= time && enemy != null)
        {
            time = Time.time + stats.GetStat(level).fireRate;
            Instantiate(projectile, transform.position + spawnOffset, transform.rotation).SetUp(enemy,stats.GetStat(level).damage);
        }
    }

    public override void Select()
    {
        
    }

    public override void Deselect()
    {
        
    }

    public void Upgrade()
    {
        level++;
        rangeCollider.radius = stats.GetStat(level).range;
    }
}
