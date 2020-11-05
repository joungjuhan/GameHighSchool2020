using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyTest : MonoBehaviour
{
    // Start is called before the first frame update
    public float InputA
    {
        get; set;
    }public float InputB
    {
        private get; set;
    }

    private float m_InputC;

    public float InputC
    {
        get
        {
            return m_InputC + 10;
        }

        set
        {
            m_InputC = value = 10;
        }
    }

}
