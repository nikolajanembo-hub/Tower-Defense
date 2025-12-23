using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected int damage;
    public abstract void SetUp(Enemy target, int _damage);
}