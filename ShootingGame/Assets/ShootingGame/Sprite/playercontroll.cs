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
    public float m_Speed = 1f;
    public Bullet m_bullet;
    public float m_AttackDelay = 0.5f;
    public float m_AttackCooldown = 0f;

    public Transform[] m_FireMuzzle;
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


        if (Input.GetKey(KeyCode.R) && m_AttackCooldown <= 0)
        {
            foreach (var FireMuzzle in m_FireMuzzle)
            {
                var bullet = GameObject.Instantiate(m_bullet, FireMuzzle.position, FireMuzzle.rotation);
            }
            m_AttackCooldown = m_AttackDelay;

        }
        m_AttackCooldown -= Time.deltaTime;
    }
}
