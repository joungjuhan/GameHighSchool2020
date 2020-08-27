using UnityEngine;

public struct DamageData
{
    public float damage;
    public object[] buff;
    public GameObject player;
}
    public interface IDamagable
    {
    void TakeDamage(DamageData damage);
    }
