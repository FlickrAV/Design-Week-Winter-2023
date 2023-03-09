using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopConveyor : MonoBehaviour
{
    private float speed = 5f;
    public HydraulicPress press;

    private void Awake()
    {
        press = GameObject.Find("Press").GetComponent<HydraulicPress>();
    }
    private void Update()
    {
        speed = Mathf.Clamp(speed, 0, 15);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (press.pressing == false && press.height > 6.5)
            {
                speed += 0.1f;
            }
        }
        else
        {
            if (press.pressing == false && press.height > 6.5f)
            {
                speed = 5f;
            }
        }

        if (transform.position.x <= -19)
        {
            transform.position = transform.position + new Vector3(48.7f, 0);
        }
        transform.position = transform.position + new Vector3(-speed, 0) * Time.deltaTime;

        if (press.pressing == true && speed > 0)
        {
            speed -= 0.5f;
        }
        if (press.pressing == false && speed < 5 && press.height > 6.5)
        {
            speed += 0.5f;
        }
    }
}
