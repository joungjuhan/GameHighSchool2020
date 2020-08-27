using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DamageData;

public class miniun : MonoBehaviour, IDamagable
{
    public void TakeDamage(DamageData damage)
    {
        Debug.LogFormat("(0)에게 죽었다.", damage.player.name);

    }
}