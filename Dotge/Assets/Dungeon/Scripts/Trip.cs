using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trip : MonoBehaviour
{
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
                player.Die();

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
