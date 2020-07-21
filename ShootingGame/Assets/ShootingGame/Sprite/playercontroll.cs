using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playercontroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * 5f * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * 5f * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 5f * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.A))
        {   
            transform.position += Vector3.left * 5f * Time.deltaTime;
        }

    }
}
