using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeongjuhan
{
    public class FllowBlackground : MonoBehaviour
    {
        public float m_Grid = 20f;

        public GameObject[] m_background;
        public Transform m_Target;

        public int m_OldMod = 0;

        public void Update()
        {
            int mod = Mathf.RoundToInt(m_Target.position.x / m_Grid); //버림
                                                                      //Mathf.Floor(); 올림
                                                                      //Mathf.cell(); 내림
                                                                      //Mathf.CLosestPowerOftwo(); 반올림
                                                                      // gird를 넘어서는 이동이 발생 갱신 필요

            if (m_OldMod != mod)
            {
                foreach (var background in m_background)
                {
                    var pos = background.transform.position;
                    pos.x += m_Grid * (mod = m_OldMod);
                    background.transform.position = pos;
                }
            }
            m_OldMod = mod;
        }
    }
}