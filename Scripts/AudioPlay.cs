using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    AudioSource ac;

    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        ac.PlayOneShot(ac.clip);
    }
}
