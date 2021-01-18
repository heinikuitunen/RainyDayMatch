using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{

    [SerializeField]
    private Transform puzzleField; // Alue, jossa muistipelin kortit ovat.

    [SerializeField]
    private GameObject btn; // Kortit.

    void Awake()
    {
        for (int i = 0; i < 32; i++) // Korttien määrä, joka on vähemmän kuin 32. Pareja alunperin oli pelissä 20 (eli yhteensä 40), mutta niitä on vähennetty 16.
        {
            GameObject button = Instantiate(btn); // "Instantiate" tekee kopion korteista.
            button.name = "" + i; // Nimeää nappulat.
            button.transform.SetParent(puzzleField, false);
        }
    }
}
