using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPComponet : MonoBehaviour
{
    public UnityEvent m_BeAteEvent;
    public virtual void BeAte()
    {
        //아이템 이벤트 처리
        m_BeAteEvent.Invoke();
        // Destroy(gameObject);
    }
    public void DestroySelf()
    {
        Destroy(gameObject);

    }
}
