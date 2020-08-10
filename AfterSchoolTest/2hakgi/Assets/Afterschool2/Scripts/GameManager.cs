using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int m_Life = 3;
    public int m_Score = 0;

    // Start is called before the first frame update
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore()
    {
        m_Score++;
    }
    public void DamageLife()
    {
        m_Life--;
        if(m_Life <= 0)
        {

        }
    }
}
