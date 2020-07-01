using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public float m_Speed = 4f;
    public float bulletDie = 5f;
// Update is called once per frame
void Update()
    {
    Rigidbody rigidbody =GetComponent<Rigidbody>();

       
    
    rigidbody.AddForce(transform.forward * m_Speed);
        bulletDie -= Time.deltaTime;

        if (bulletDie <= 0)
            gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody != null & other.attachedRigidbody.tag == "Player")
        {
            var player = other.attachedRigidbody.GetComponent<PlayerController>();
            player.Die();
           
        }
    
    }
   
}
