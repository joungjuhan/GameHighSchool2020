using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float m_Speed = 2f;
    // Update is called once per frame
    private void Update()
    {
        Vector3 velocity = transform.up* m_Speed; //방향 *시간
        Vector3 movement = velocity * Time.deltaTime;  
        transform.position += movement;
        //        transform.position += transform.up * m_Speed * Time.deltaTime;
       //  Vector3 movement = transform.up * m_Speed * Time.deltaTime;
    }
}
