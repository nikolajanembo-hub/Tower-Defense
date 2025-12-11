using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private Enemy enemy;
    private List<Enemy> enemiesInRange = new List<Enemy>();
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;
    [SerializeField] private TowerProjectile projectile;
    [SerializeField] Vector3 spawnOffset;
    private float time;
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
            time = Time.time + fireRate;
            Instantiate(projectile, transform.position + spawnOffset, transform.rotation).SetUp(enemy,damage);
        }
    }
}
