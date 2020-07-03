using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text m_ScoreUI;
    public Text m_RestarUI;

    public PlayerController m_playerController;
    public List<GameObject> m_BulletSpanwers;

    public bool m_IsPlaying; //상태를 나타내주는 불변수
    public float m_Score;//점수 


    // Start is called before the first frame update
    private void Start()
    {
       // Gamestart();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlaying)
        {
            m_Score = m_Score + Time.deltaTime;
            m_ScoreUI.text = string.Format("Score: {0}", m_Score);
        }
    }
}
