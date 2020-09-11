using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPComponet : MonoBehaviour
{
    public int m_HP = 10;


    public UnityEvent m_BeAteEvent;
    public UnityEvent m_OnDie;
    public virtual void TakeDamage(int damage)
    {
        //아이템 이벤트 처리
        m_BeAteEvent.Invoke();
        // Destroy(gameObject);

        m_HP -= damage;
        if(m_HP <= 0)
        {
            m_OnDie.Invoke();
        }

    }
    public void DestroySelf()
    {
        Destroy(gameObject);

    }
}
