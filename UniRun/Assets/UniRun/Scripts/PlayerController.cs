﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator m_Animator;
    public Rigidbody2D m_Rigidbody2D;
    public AudioSource m_audioSource;


    public AudioClip m_Jump;
    public AudioClip m_Die;

    public bool m_IsGround = false;
    public bool m_IsDead = false;

    public int m_JumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    m_Animator.SetBool("IsGround", true);
        //    //  m_Animator.SetFloat();
        //    //m_Animator.SetTrigger();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    m_Animator.SetBool("IsGround", false);

        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    m_Animator.SetBool("IsDead", true);
        //}
        if (m_IsDead) return;

        m_Animator.SetBool("IsGround", m_IsGround);

        if (Input.GetKeyDown(KeyCode.Space) && m_JumpCount < 2)
        {
            m_Rigidbody2D.AddForce(Vector2.up * 400);
            m_Rigidbody2D.velocity = Vector2.zero;
            m_JumpCount++;

            m_audioSource.clip = m_Jump;
            m_audioSource.Play();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            m_JumpCount = 0;
            m_IsGround = true;
        }
        
            
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            m_IsGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            m_IsDead = true;
            m_Animator.SetBool("IsDead", m_IsDead);

            GameManager.Instance.OnPlayerDead();

            m_audioSource.clip = m_Die;
            m_audioSource.Play();
        }
    }
    
}
