using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trip : MonoBehaviour
{
    public UnityEvent m_OnEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("안에 있음:");
        if (other.attachedRigidbody != null)
        {
            var player = other.attachedRigidbody.GetComponent<PlayerController_Dungeon>();
            if (player != null)
                m_OnEnter.Invoke();

        }
        Debug.Log("들어감");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("나감");

    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("유지");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
