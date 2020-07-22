using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Bullet m_bullet;
    

    public Transform[] m_FireMuzzle;
    public float m_AttackDelay = 0.5f;
    public float m_AttackCooldown = 0f;

    public bool isDead = false;
    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * 2f * Time.deltaTime;
        if (!isDead && m_AttackCooldown <= 0)
        {
            foreach (var FireMuzzle in m_FireMuzzle)
            {
                var bullet = GameObject.Instantiate(m_bullet, FireMuzzle.position, FireMuzzle.rotation);
                m_AttackCooldown = m_AttackDelay;
            }
            m_AttackCooldown -= Time.deltaTime;
        }

    }
    public Animator m_Animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            m_Animator.SetBool("Die", true);
            isDead = true;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
