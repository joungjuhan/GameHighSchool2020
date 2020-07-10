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
    //public List<GameObject> m_BulletSpanwers;
    //public List<GameObject> m_RotationBulletSpawner;
    public Text m_ClearUI;
    public Text m_ScoreUI;

    public float m_Score;//점수 
    public bool m_IsPlaying;

    public void Start()
    {
        GameStart();

    }
    
    public void GameStart()
    {
        //출발 시점에서 플레이어가 스폰  
        m_IsPlaying = true;  //플레이어를 활성화하고
        m_Score = 0f;
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
        //게임 클리어 메세지가 보이지 않는다 ,
        m_ClearUI.gameObject.SetActive(false);
       // 게임스코메시지가보인다
        m_ScoreUI.gameObject.SetActive(true);
    }
    public void GameClear()
    {
        m_IsPlaying = false;
        //플레이어가 비활성화
        m_Player.gameObject.SetActive(false);
        //게임 클리어 메세지가 보인다
        m_ClearUI.gameObject.SetActive(true);
        //게임 스코어 메시지가 보인다
        m_ScoreUI.gameObject.SetActive(true);

        //활성화 된적은 비활성화
        //for (int i = 0; i < m_BulletSpanwers.Count; i++)
        //{
        //    m_BulletSpanwers[i].gameObject.SetActive(false);
        //}
        //for (int i = 0; i < m_RotationBulletSpawner.Count; i++)
        //{
        //    m_RotationBulletSpawner[i].gameObject.SetActive(false);
        //}
        ////탄환 삭제
        //Bullet[] bullets = FindObjectsOfType<Bullet>();

        //for (int i = 0; i < bullets.Length; i++)
        //{
        //    Destroy(bullets[i].gameObject); 
        //}
        var enemisType1 = FindObjectsOfType<RotationBulletSpawner>();
        foreach (var enemy in enemisType1)
        {
            enemy.gameObject.SetActive(false);
        }
        var enemisType2 = FindObjectsOfType<BulletSpawner>();
        foreach (var enemy in enemisType2)
        {
            enemy.gameObject.SetActive(false);
        }
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject); //Destory(게임오브젝트) 게임오브젝트를 제거함 
        }

        float num1 =PlayerPrefs.GetFloat("num1", 999);
        float num2 = PlayerPrefs.GetFloat("num2", 999);
        float num3 = PlayerPrefs.GetFloat("num3", 999);


        if (m_Score < num1)
        {
            num3 = num2;
            num2 = num1;
            num1 = m_Score;
        }
        else if (m_Score < num2)
        {
            num3 = num2;
            num2 = m_Score;
        }
        else if (m_Score < num3)
        {
            num3 =m_Score;
        }
        PlayerPrefs.SetFloat("num1",num1);
        PlayerPrefs.SetFloat("num2",num2);
        PlayerPrefs.SetFloat("num3",num3);
        PlayerPrefs.Save();

        m_ClearUI.text = string.Format("Game Clear\n 1위 : {0}\n 2위 : {1}\n 3위: {2}", num1, num2 , num3);

    }

    //public void SetActivityAllGameObject(Type Type, bool inActivity)
    //{
    //    var gameObjects = FindObjectsOfType(type);
    //    foreach (var gObj in objects)
    //    {
    //        var qObj = (GameObject)obj;
    //        qObj.SetActive(false); 
    //    }
    //}                     //함수로도 할수 있다는것을 알려줌 
    //privite은 자신만 public은 공유가능
    public void ReturnToStartPoint()
    {
        m_Score = 0;
        //플레이어를 출발 지점으로 되돌린다.
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
    }
    // Update is called once per frame
    public void Update()
    {
        if (m_Player)
        {
           m_Score += Time.deltaTime;
            m_ScoreUI.text = string.Format("Score: {0}", m_Score);
        }
    }
}
