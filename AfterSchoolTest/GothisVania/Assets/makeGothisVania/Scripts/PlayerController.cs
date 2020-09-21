using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {

        float xAxis= Input.GetAxis("Horizontal");//좌우입력

        float sMovement= speed * xAxis * Time.deltaTime;
        Vector3 movement = Vector3.right * sMovement;
        transform.position += movement;

    }

}
