using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public List<ItemComponet> m_Items = new List<ItemComponet>();

    public bool m_IsGameOver;
    public GameObject m_GameOverUI;
    public GameObject m_GameClearUI;
    public JointArm m_JointArm;
    public GameObject m_Player;
    public Transform m_StartPoint;

    public bool m_IsPlaying;

    public UnityEngine.UI.Button m_JumpButten;

    public void Start()
    {
        m_Items.AddRange(FindObjectsOfType<ItemComponet>());
        m_IsPlaying = true;
        m_GameClearUI.gameObject.SetActive(false);

        GameStart();
    }


   
    public void Update()
    {
        if (!m_IsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
        bool result = true;
        foreach(var item in m_Items)
        {
            if (item != null)
                result = false;
        }
        if(result)
        {
            m_IsPlaying = false;
            GameClear();
        }
    }
    public VariableJoystick m_Joystick;

    public void GameStart()
    {
        

        var playerInstance = Instantiate(m_Player, m_StartPoint.position, m_StartPoint.rotation);
        m_JointArm.m_Target = playerInstance.transform;

        var hpComponent = playerInstance.GetComponent<HPComponet>();
        hpComponent.m_OnDie.AddListener(GameOver);

        var playerControllor = playerInstance.GetComponent<PlayerController>();
        playerControllor.m_Joystick = m_Joystick;

        m_JumpButten.onClick.AddListener( playerControllor.Jump);
    }

    public void GameOver()
    {
        m_IsGameOver = true;
        m_GameOverUI.SetActive(true);
    }
    public void GameClear()
    {
        m_GameClearUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("GameClear");
    }
}
