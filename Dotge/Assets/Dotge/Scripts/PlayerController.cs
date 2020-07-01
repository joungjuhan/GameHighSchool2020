using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float m_Speed = 25f;
    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody =/*gameObject.*/GetComponent<Rigidbody>();


        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
      //  float DAxis = Input.GetAxis("fire1");

        rigidbody.AddForce(new Vector3(xAxis, 0, yAxis) * m_Speed);
        //{
        //    // transform.position += Vector3.left * 5f * Time.deltaTime;
        //    rigidbody.AddForce(Vector3.left * m_Speed);
        //    Debug.Log("좌");
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    rigidbody.AddForce(Vector3.right * m_Speed);
        //    Debug.Log("우");
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    rigidbody.AddForce(Vector3.forward * m_Speed);
        //    Debug.Log("위");
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    rigidbody.AddForce(Vector3.back * m_Speed);
        //    Debug.Log("아래");
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //    Die();
       
            }


    public void Die()
    {
        Debug.Log("사망");
        gameObject.SetActive(false);
    }
}
