using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopConveyor : MonoBehaviour
{
    private float speed = 5f;

    void FixedUpdate()
    {
        if (transform.position.x <= -19)
        {
            transform.position = transform.position + new Vector3(48.7f, 0);
        }
        transform.position = transform.position + new Vector3(-speed, 0) * Time.deltaTime;
    }
}
