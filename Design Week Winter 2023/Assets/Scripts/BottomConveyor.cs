using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomConveyor : MonoBehaviour
{
    private float speed = 5f;
    private HydraulicPress press;


    private void Awake()
    {
        press = GameObject.Find("Press").GetComponent<HydraulicPress>();
    }
    void FixedUpdate()
    {
        if (transform.position.x >= 25)
        {
            transform.position = transform.position + new Vector3(-48.85f, 0);
        }
        transform.position = transform.position + new Vector3(speed, 0) * Time.deltaTime;

        if (press.pressing == true && speed > 0)
        {
            speed -= 0.5f;
        }
        if (press.pressing == false && speed < 5)
        {
            speed += 0.5f;
        }
    }
}