using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int m_Life = 3;
    public int m_Score = 0;

    // Start is called before the first frame update
    public static GameManager Instance;
    public CubeSpawner1 m_cubeSpawner1;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        m_cubeSpawner1.SpawnStart(); 
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
            m_cubeSpawner1.gameObject.SetActive(false);
        }
    }
}
