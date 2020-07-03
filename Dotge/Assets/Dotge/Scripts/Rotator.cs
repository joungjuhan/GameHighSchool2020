using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject m_Rotator;

    public float m_RotatorSpeed = 30f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, m_RotatorSpeed * Time.deltaTime, 0));

    }
}
