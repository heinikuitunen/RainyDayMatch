using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamCatcher : MonoBehaviour
{
    public Animator animDC;
    public bool onDC = false;

    void Start()
    {
        animDC = GetComponent<Animator>();
    }

    void Update()
    {
        if (onDC == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animDC.SetBool("isClicked", true);
            }
        }

        if (onDC == false)
        {
            animDC.SetBool("isClicked", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onDC = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onDC = false;
        }
    }
}
