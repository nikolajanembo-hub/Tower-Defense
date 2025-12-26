using System;
using DG.Tweening;
using UnityEngine;

public class BombProjectile : Projectile
{
    [SerializeField] private float explosionRange = 3f;
    [SerializeField] private float height = 5f;
    [SerializeField] private ParticleSystem particle;    
    public override void SetUp(Enemy target, int _damage)
    {
        damage =  _damage;
        transform.DOJump(target.transform.position, height, 1, speed).SetEase(Ease.Linear).onComplete += DoDamage;
    }

    private void DoDamage()
    {
        var detected = Physics.OverlapSphere(transform.position, explosionRange);

        foreach (var item in detected)
        {
            var enemy = item.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                enemy.Hit(damage);
            }
        }
        Instantiate(particle, transform.position, particle.transform.rotation);
        Destroy(gameObject); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionRange);
    }
}

