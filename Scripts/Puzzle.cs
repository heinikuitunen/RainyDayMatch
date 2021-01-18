using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{

    public GameObject dialogueBox;
    public Text dialogue;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideBox());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        StartCoroutine(ShowBox());
    }

    IEnumerator ShowBox()
    {
        dialogueBox.SetActive(true);
        dialogue.enabled = true;
        yield return new WaitForSeconds(5);
        yield return HideBox();
    }

    IEnumerator HideBox()
    {
        dialogueBox.SetActive(false);
        dialogue.enabled = false;
        yield return new WaitForSeconds(2);
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("MemoryGame", LoadSceneMode.Single);
    }
}
