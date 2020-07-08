using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trip2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("들갔떄");
        if (collision.rigidbody != null)
        {
            var player = collision.rigidbody.GetComponent<PlayerController_Dungeon>();
            if (player != null)
                player.Die();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("나올떄");

    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("있을떄");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
