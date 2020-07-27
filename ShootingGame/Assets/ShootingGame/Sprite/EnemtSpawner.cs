using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;

    public float m_SpawnIntervalMin = 2f;
    public float m_SpawnIntervalMax = 6f;

    public int m_MinSpawncount = 1;
    public int m_MaxSpawncount = 4;

    public float m_SpawnCooldown = 0f;
    private void Start()
    {
        m_SpawnCooldown = Random.Range(m_SpawnIntervalMin, m_SpawnIntervalMax);

    }
    // Update is called once per frame
    void Update()
    {
        if (m_SpawnCooldown <= 0)
        {
            int spawncount = Random.Range(m_MinSpawncount, m_MaxSpawncount);

            List<int> spawnNums = new List<int>();
            for (int i = 0; i < spawncount; i++)
            {
                {
                    int spawnNum;
                    do
                    {
                        spawnNum = Random.Range(0, m_SpawnPoints.Length);
                    }
                    while (spawnNums.Contains(spawnNum));
                    spawnNums.Add(spawnNum);
                }

                foreach (var spawnNum in spawnNums)
                {
                    var eulerAngle = m_SpawnPoints[spawnNum].eulerAngles += Vector3.forward * Random.Range(-15f, 15f);
                    GameObject bullet = GameObject.Instantiate(m_EnemyPrefab,
                        m_SpawnPoints[spawnNum].position, Quaternion.Euler(eulerAngle));
                }
            }
            m_SpawnCooldown = Random.Range(m_SpawnIntervalMin, m_SpawnIntervalMax);

        }
        m_SpawnCooldown -= Time.deltaTime;

    }
}
