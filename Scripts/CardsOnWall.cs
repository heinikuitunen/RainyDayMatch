using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsOnWall : MonoBehaviour
{
    public GameObject Panel;
    public Button btn;

    public void Start()
    {
        Panel.SetActive(false);
        btn.gameObject.SetActive(false);
    }

    public void OpenPanel()
    {
        if(Panel != null)
        {
            Panel.SetActive(true);
        }
    }

    public void OnMouseDown()
    {
        OpenPanel();
        Button();
    }

    public void HidePanel()
    {
        Panel.SetActive(false);
    }

    public void Button()
    {
        if(btn != null)
        {
            btn.gameObject.SetActive(true);
        }

    }
    
}
