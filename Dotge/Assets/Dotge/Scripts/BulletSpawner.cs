using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    //public Transform m_PlayerTransform;

    public GameObject m_Bullet;

    public float m_RotationSpeed = 60f;
    public float m_spawnbullet = 1f;
    private float m_spawncho = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        //시간계산
        m_spawncho += Time.deltaTime;
        if (m_spawncho >= m_spawnbullet)
        {

           
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation; //회전한 정도 
            var b = bullet.GetComponent<Bullet>();
            b.m_Velocity = transform.forward;
            //초기화
            m_spawncho = 0;
        }

        // GameObject.Find("Player ");  // 게임오브젝트의 이름 ,거의 안씀
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //주로 사용 Player
        //GameObject.FindObjectOfType<PlayerController>(); //그다음으로 사용 

        //GameObject.FindGameObjectsWithTag("Player");//모두사용
        //transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0); // 회전한 함수 
        if(player != null)
        {
            Vector3 attacketPoint = player.transform.position;
            attacketPoint.y = transform.position.y;
            transform.LookAt(attacketPoint);//플레이어 방향으로감

        }


    }
}
