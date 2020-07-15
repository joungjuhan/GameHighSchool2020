using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private float width;
    // Start is called before the first frame update
   

    private void Awake()
    {
         var collider = GetComponent<BoxCollider2D>();
          width = collider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width)
        {
            transform.position += Vector3.right * 2f * width;
           // transform.position = new Vector3(width, 0, 0);
        }
    }

}
