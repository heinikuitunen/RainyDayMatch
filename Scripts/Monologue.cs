using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Monologue : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideBox());
    }

    void OnMouseDown()
    {
        StartCoroutine(ShowBox());
    }

    IEnumerator HideBox()
    {
        yield return new WaitForSeconds(0);
        dialogueBox.SetActive(false);
        dialogue.enabled = false;
    }

    IEnumerator ShowBox()
    {
        dialogueBox.SetActive(true);
        dialogue.enabled = true;
        yield return new WaitForSeconds(5);
        yield return HideBox();
    }

}
