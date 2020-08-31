using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;

    public Transform m_Sprite;
    
    public float m_XAxisSpeed = 3f;
    public float m_YJumpPower = 3f;
    public float m_JumpCount = 0f;

    public bool Jumpbool;
    public bool m_IsClimbing = false;
    public bool m_IsJumping = false;
    private Animator m_Animator;
    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * m_XAxisSpeed;
        m_Rigidbody2D.velocity = velocity;
        //ㅈㅍ
        if(Jumpbool)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                m_Rigidbody2D.AddForce(Vector3.up * m_YJumpPower);

                Jumpbool = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            m_Rigidbody2D.AddForce(Vector3.down * m_YJumpPower);

        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody2D.AddForce(Vector3.down * -yAxis);
        }

        //캐릭터 스프라이트 방향따라가기
        if (xAxis > 0)
            transform.localScale = new Vector3(1,1,1);
        if (xAxis < 0)
            transform.localScale = new Vector3(-1,1,1);

        var animator = GetComponent<Animator>();
        animator.SetFloat("VelocityY", velocity.y);

        m_IsJumping = Mathf.Abs(velocity.y) >= 0.1f ? true : false;

        m_Animator.SetBool("IsJumping", m_IsJumping);
        m_Animator.SetFloat("Velocity", Mathf.Abs(xAxis));
        m_Animator.SetFloat("Velocity", velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Jumpbool = true;
        }
        if (collision.gameObject.tag == "ladder")
        {
            Jumpbool = false;
        }

    }
}
