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
    public float m_ClimbSpeed = 2f;

    public bool Jumpbool;
    public bool m_IsClimbing = false;
    public bool m_IsJumping = false;
    public bool m_m_Isclimbing = false;
    public bool m_IsTouchLadder = false;
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


        if(m_IsTouchLadder == true && Mathf.Abs(yAxis) > 0.5f)
        {
            m_IsClimbing = true;
        }

        if(!m_IsClimbing)
        {
            Vector2 velocity = m_Rigidbody2D.velocity;
            velocity.x = xAxis * m_XAxisSpeed;
            m_Rigidbody2D.velocity = velocity;
            //ㅈㅍ
            if (Jumpbool)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_Rigidbody2D.AddForce(Vector3.up * m_YJumpPower);

                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                m_Rigidbody2D.AddForce(Vector3.down * m_YJumpPower);

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Rigidbody2D.AddForce(Vector3.down * -yAxis);
                Jumpbool = false;

            }

            //캐릭터 스프라이트 방향따라가기
            if (xAxis > 0)
                transform.localScale = new Vector3(1, 1, 1);
            if (xAxis < 0)
                transform.localScale = new Vector3(-1, 1, 1);

            var animator = GetComponent<Animator>();
            animator.SetFloat("Velocity", velocity.y);

            m_IsJumping = Mathf.Abs(velocity.y) >= 0.1f ? true : false;

            m_Animator.SetBool("isJumping", m_IsJumping);
            m_Animator.SetFloat("VelocityX", Mathf.Abs(xAxis));
            m_Animator.SetFloat("VelocityY", velocity.y);

        }
        else
                {
                    m_Rigidbody2D.constraints = m_Rigidbody2D.constraints 
                    | RigidbodyConstraints2D.FreezePosition;
                Vector3 movement = Vector3.zero;
                movement.x = xAxis * Time.deltaTime;
                movement.y = yAxis * Time.deltaTime;
            transform.position += movement;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                ClimbExit();
            }
            m_Animator.SetBool("IsClimbing", m_IsClimbing);
            m_Animator.SetFloat("ClimbSpeed", Mathf.Abs(xAxis) + Mathf.Abs(yAxis));
                }
    }
    private void ClimbExit()
    {
        m_Rigidbody2D.constraints = m_Rigidbody2D.constraints & ~RigidbodyConstraints2D.FreezePosition;
        m_IsClimbing = false;

        m_Animator.SetBool("IsClimbing", m_IsClimbing);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Jumpbool = true;
        }
     

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_IsTouchLadder = true;

        }
        else if(collision.tag == "Item")
        {
            var item = collision.GetComponent<ItemComponet>(); 
            
            if(item != null)
              item.BeAte();
            
        }
    }

   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag =="Ladder")
        {
            m_IsTouchLadder = false;

            ClimbExit();
        }
    }

}
