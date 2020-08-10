using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    public float m_speed = 5; 
    public void OnPointerDownEvent()
    {
        GameManager.Instance.AddScore();
        Destroy(gameObject);
    }

    void Update()
    {
        var fall = Vector3.down * m_speed * Time.deltaTime;
        transform.position += fall;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
        {
            GameManager.Instance.DamageLife();
            Destroy(gameObject);
        }
    }
}
