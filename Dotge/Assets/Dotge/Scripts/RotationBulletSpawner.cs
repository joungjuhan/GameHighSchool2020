using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class RotationBulletSpawner : MonoBehaviour
{

    public GameObject m_Bullet;

    public float m_RotationSpeed = 60f;
    public float m_spawnbullet = 1f;
    private float m_spawncho = 0f;

    void Update()
    {

        //시간계산
        m_spawncho += Time.deltaTime;
        if (m_spawncho >= m_spawnbullet)
        {


            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation; //회전한 정도 

            //초기화
            m_spawncho = 0;
        }

        
        transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0); // 회전한 함수 
       

    }
}
