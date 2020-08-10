using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : MonoBehaviour
{
    public float m_speed = 5;
    public void OnPointerDownEvent()
    {
        GameManager.Instance.DamageLife();
        Destroy(gameObject);
    }

    void Update()
    {
        var fall = Vector3.down * m_speed * Time.deltaTime;
        transform.position += fall;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plane")
        {
            GameManager.Instance.AddScore();
            Destroy(gameObject);     
            
        }
    }
    // Start is called before the first frame update

}
