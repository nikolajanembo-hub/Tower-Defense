using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed; 
    protected int damage;
    public abstract void SetUp(Enemy target, int _damage);
}