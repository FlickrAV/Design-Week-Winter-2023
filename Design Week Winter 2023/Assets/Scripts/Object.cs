using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private float speed = 5f;
    private bool againstPress = false;
    private bool againstBelt = false;
    private Animator anim;
    private HydraulicPress press;
    private int animSpeed;
    public int moneyGained;
    [HideInInspector]
    public bool crushed = false;
    private bool moneyReceived = false;
    private GameManager manager;
    private AudioSource audioSource;
    public AudioSource luigiSource;
    public bool soundStart = false;
    bool sounStarted = false;
    // Start is called before the first frame update
    void Awake()
    {
        press = GameObject.Find("Press").GetComponent<HydraulicPress>();
        anim = GetComponent<Animator>();
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() 
    {
        if(gameObject.tag == "Luigi")    
        {
            luigiSource.PlayDelayed(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(againstBelt && againstPress)
            animSpeed = 1;
        else
            animSpeed = 0;

        anim.SetFloat("animSpeed", animSpeed);

        if(crushed && !moneyReceived)
        {
            manager.money += moneyGained;
            moneyReceived = true;
        }

        if(soundStart && !sounStarted)
        {
            audioSource.Play();
            sounStarted = true;
        }
        speed = Mathf.Clamp(speed, 0, 15);
    }

    private void FixedUpdate()
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

        if (transform.position.x <= -15)
        {
            manager.SpawnNewObject();
            Destroy(gameObject);
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

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.name == "Press")    
        {
            againstPress = true;
        }

        if(other.gameObject.tag == "Conveyor Belt")    
        {
            againstBelt = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.name == "Press")    
        {
            againstPress = false;
        }

        if(other.gameObject.tag == "Conveyor Belt")    
        {
            againstBelt = false;
        }
    }
}
