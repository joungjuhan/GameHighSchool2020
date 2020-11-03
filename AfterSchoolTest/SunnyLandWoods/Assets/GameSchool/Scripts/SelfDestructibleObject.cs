using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeongjuhan
{
    public class SelfDestructibleObject : MonoBehaviour

    {
        public void selfDestroy()
        {
            Destroy(gameObject);
        }
    }
}