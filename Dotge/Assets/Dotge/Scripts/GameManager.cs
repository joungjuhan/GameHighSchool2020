using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        GameStart(); //게임시작
    }

    // Start is called before the first frame update
    public Text m_ScoreUI;
    public Text m_RestarUI;

    public PlayerController m_playerController;
    public List<GameObject> m_BulletSpanwers;

    public bool m_IsPlaying; //상태를 나타내주는 불변수
    public float m_Score;//점수 

    private void GameStart()  //게임시작되면
    {
        //gameobject.Setactive() 게임오브젝트 비활성화가 가능 (삭제아니고 눈에만)
        m_IsPlaying = true;  //플레이어를 활성화하고
        m_Score = 0f; //스코어 0
        m_RestarUI.gameObject.SetActive(false);  //리스타트ui 비활
        m_playerController.gameObject.SetActive(true); //플레이어 활성화
        //불렛스포너들 활성화
        for(int i=0; i<m_BulletSpanwers.Count; i++)
        {
            m_BulletSpanwers[i].gameObject.SetActive(true);
        }
       // Gamestart();
    }

    public void GameOver()
    {
        m_IsPlaying = false;
        m_RestarUI.gameObject.SetActive(true);
        m_playerController.gameObject.SetActive(false);
        
        for(int i = 0; i <m_BulletSpanwers.Count; i++)
        {
            m_BulletSpanwers[i].gameObject.SetActive(false);
        }
        //총알제거
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i< bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject); //Destory(게임오브젝트) 게임오브젝트를 제거함 
        }
         
        //TopScore 키를 가지고 최고점 가지고옴
        float topScore = PlayerPrefs.GetFloat("TopScore", 0);
        if(topScore < m_Score) //현재 내가 낸 점수가 최고 기록이 높으면 
        {
            topScore = m_Score; //내가낸 점수로 최고율 변경
        }
        PlayerPrefs.SetFloat("TopScore", topScore); //탑스코어에 최고점을 저장하고
        PlayerPrefs.Save(); //저장 
        //RestarUI 최고점 표시
        m_RestarUI.text
            =string.Format("게임오버 다시시작 R \n최고점 : {0}\n다시 시작하시려면 R버튼을 누르세요.", topScore);
    }
    // Update is called once per frame
    void Update()
    {
        //시간당 점수업 
        if (m_IsPlaying)
        {
            m_Score = m_Score + Time.deltaTime;
            m_ScoreUI.text = string.Format("Score: {0}", m_Score);
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                    GameStart();
                }

        }
    }
}
