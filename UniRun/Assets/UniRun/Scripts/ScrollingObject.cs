using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float m_Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 position = transform.position;
        //position.x = position.x + m_Speed * Time.deltaTime;
        //transform.position = position;
        transform.position += Vector3.left * m_Speed * Time.deltaTime;
    }
}
