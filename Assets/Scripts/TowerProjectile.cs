using System;
using UnityEngine;

public class TowerProjectile : Projectile
{
    public Enemy target;
    
        private void Update() 
        { 
            if (target == null || target.gameObject.activeInHierarchy == false)
            {
                Destroy(gameObject);
                return;
            } 
            Vector3 direction = (target.transform.position + Vector3.up) - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
            transform.forward = direction.normalized;
     
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Hit(damage);
                Destroy(gameObject);
            }
        }
        public override void SetUp(Enemy target, int _damage)
        {
            this.target = target;
            damage = _damage;
        }
}
