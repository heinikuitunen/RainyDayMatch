using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPainting : MonoBehaviour
{
    public Animator animFish;
    public bool onFish = false;

    // Start is called before the first frame update
    void Start()
    {
        animFish = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onFish == true)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                animFish.SetBool("fishClicked", true);
            }
        }

        if(onFish == false)
        {
            animFish.SetBool("fishClicked", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            onFish = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            onFish = false;
        }
    }
}
