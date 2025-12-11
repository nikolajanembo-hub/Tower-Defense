using System;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    public Enemy target;
    private int damage;
    [SerializeField] private float projectileSpeed;
    
        private void Update() 
        { 
            if (target == null || target.gameObject.activeInHierarchy == false)
            {
                Destroy(gameObject);
                return;
            } 
            Vector3 direction = (target.transform.position + Vector3.up) - transform.position;
            transform.position += direction.normalized * projectileSpeed * Time.deltaTime;
            transform.forward = direction.normalized;
     
        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.TryGetComponent(out Enemy enemy))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        public void SetUp(Enemy _target, int _damage)
        {
            target = _target;
            damage = _damage;
        }
}
