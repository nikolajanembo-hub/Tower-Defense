using DG.Tweening;
using UnityEngine;

public class BombProjectile : Projectile
{
    
    public override void SetUp(Enemy target, int _damage)
    {
        damage =  _damage;
        transform.DOJump(target.transform.position, 2f, 1, 2f).onComplete += DoDamage;
    }

    private void DoDamage()
    {
        var detected = Physics.OverlapSphere(transform.position, 3f);
        // prodji kroz collidere proveri da li su enemy ako jesu uradi dmg
        //novi tower sa bomb projectileom
        //UI button za 2 odvojena towera koji uzimaju ime towera koji je assignovan na njih
    }
}
