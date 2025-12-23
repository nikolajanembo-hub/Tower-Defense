using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerStats", menuName = "Scriptable Objects/TowerStats")]
public class TowerStats : ScriptableObject
{
    [SerializeField] private List<TowerStat> towerStats = new List<TowerStat>();

    public TowerStat GetStat(int level)
    {
        if (towerStats.Count == 0)
        {
            return null;
        }
        return towerStats[Mathf.Clamp(level,0,towerStats.Count)];
    }
    
    [Serializable] public class TowerStat
    {
        public float fireRate;
        public float range;
        public int damage;
        public int cost;
    }
}
