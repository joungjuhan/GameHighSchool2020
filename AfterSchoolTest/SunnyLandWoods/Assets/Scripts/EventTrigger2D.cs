using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger2D : MonoBehaviour
{
    [System.Flags]
    public enum Mask
    {
        None = 0,
            Player = (1 << 0 ),
            Enemy = (1<<1),
            Ect = (1<<2),
            All = Player| Enemy,
    }

    public Mask m_Mask;
    public UnityEvent m_OnTriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((m_Mask & Mask.Player) == Mask.Player)
        {
            if (collision.attachedRigidbody.tag == "Player")
                m_OnTriggerEnter.Invoke();
        }
    }


}
