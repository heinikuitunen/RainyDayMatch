using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCup : MonoBehaviour
{
    public Animator anim;
    public bool onTeaCup = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (onTeaCup == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetBool("IsClicked", true);
            }
        }

        if (onTeaCup == false)
        {
            anim.SetBool("IsClicked", false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            onTeaCup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        { 
            onTeaCup = false;
        }
    }

}
