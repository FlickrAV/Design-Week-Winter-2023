using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraulicPress : MonoBehaviour
{
    public int speed = 2;
    private Vector3 initialPos;
    private Rigidbody2D rb;
    private float t;
    public float height;
    public bool pressing = false;
    // Start is called before the first frame update

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        height = transform.position.y;
    }

    private void FixedUpdate() 
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce((Vector2.down * speed), ForceMode2D.Impulse);
            //rb.velocity = new Vector2(0, -speed);
            t = 0;
            pressing = true;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, initialPos, t);
            t += Time.deltaTime/50;
            pressing = false;
        }
    }
}
