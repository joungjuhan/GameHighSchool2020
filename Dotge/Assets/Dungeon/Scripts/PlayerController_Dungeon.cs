using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class PlayerController_Dungeon : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public float m_Speed = 0f;
    public PlayerController_Dungeon m_playerController_Dungeon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        // rigidbody.AddForce(new Vector3(xAxis, 0, zAxis) * m_Speed);

        Vector3 velocity = new Vector3(xAxis, 0, zAxis) * m_Speed;
        //Rigidbody를 이요한 이동 처리
        velocity.y = m_Rigidbody.velocity.y;//
        m_Rigidbody.velocity = velocity; //중력고정?

        //이건 물리라 벽뚤안됨



        //transform을 이용한 이동 처리

        //Vector3 movement = velocity * Time.deltaTime;
        //transform.position = transform.position + movement;
        //위에는 속도가 빠르면 벽뚫
        //transform.position = transform.position + movement;
        //transform.position; //월드 위치 좌표
        // transform.rotation; //월드 회전값
        // transform.lossyScale //월드 스케일값
        //transform.localPosition//부모에 자신의 위치정보
        //transform.localRotation//부모에 자신의 회전정보
        // transform.localScale//부모에 자신의 크기 정보
    }
    public void Die()
    {
        Debug.Log("사망");
        Destroy(gameObject);
        GameManager_Dungeon gameManager = FindObjectOfType<GameManager_Dungeon>();
        gameManager.ReturnToStartPoint();
    }
}
