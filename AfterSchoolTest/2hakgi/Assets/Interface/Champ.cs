using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DamageData;

public class Champ : MonoBehaviour, IDamagable
{
    public void TakeDamage(DamageData damage)
    {
        Debug.LogFormat("(0)에서 챔피언은 (1)의 대미지를 받았다.", damage.player.name, damage.damage);
    }
}