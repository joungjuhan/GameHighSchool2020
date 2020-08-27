using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float m_speed = 3f;
    // Update is called once per frame
    void Update()
    {
        float xAix = Input.GetAxis("Horizontal");

        var rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.AddForce(xAix * m_speed * Vector3.right);

        if (Input.GetKeyDown(KeyCode.Space))
            rigidbody2d.AddForce(400 * Vector2.up);
    }
}
