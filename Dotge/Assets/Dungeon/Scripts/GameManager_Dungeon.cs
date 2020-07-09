using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Dungeon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform m_StartPoint;
    public PlayerController_Dungeon m_Player;

    public Text m_ClearUI;
    public Text m_ScoreUI;

    public void Start()
    {
        GameStart();
    }
    private void GameStart()
    {
        //출발 시점에서 플레이어가 스폰  
       
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
        //게임 클리어 메세지가 보이지 않는다 ,
        m_ClearUI.gameObject.SetActive(false);
       // 게임스코메시지가보인다
        m_ScoreUI.gameObject.SetActive(true);
    }
    private void GameClear()
    {
        //플레이어가 비활성화
        m_Player.gameObject.SetActive(false);
        //게임 클리어 메세지가 보인다
        m_ClearUI.gameObject.SetActive(true);
        //게임 스코어 메시지가 보인다
        m_ScoreUI.gameObject.SetActive(true);

         
    }

    //privite은 자신만 public은 공유가능
    public void ReturnToStartPoint()
    {
        //플레이어를 출발 지점으로 되돌린다.
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
