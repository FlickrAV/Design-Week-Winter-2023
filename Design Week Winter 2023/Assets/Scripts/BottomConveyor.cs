using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomConveyor : MonoBehaviour
{
    private float speed = 5f;

    void FixedUpdate()
    {
        if (transform.position.x >= 25)
        {
            transform.position = transform.position + new Vector3(-48.85f, 0);
        }
        transform.position = transform.position + new Vector3(speed, 0) * Time.deltaTime;
    }
}