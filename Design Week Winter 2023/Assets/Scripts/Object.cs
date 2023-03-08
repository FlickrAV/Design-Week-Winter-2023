using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private bool againstPress = false;
    private bool againstBelt = false;
    private Animator anim;
    public int animSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(againstBelt && againstPress)
            animSpeed = 1;
        else
            animSpeed = 0;

        anim.SetFloat("animSpeed", animSpeed);
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
