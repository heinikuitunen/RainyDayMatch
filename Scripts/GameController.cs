using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private Sprite bgImage; // Kortin takakansi

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    void Start()
    {
        GetButtons(); // Hakee nappulat.
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage; // Laittaa nappuloille haluttu kortin takakansi.
        }
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void AddListeners() // Nappulan funktio on nimeltään "Listener".
    {
        foreach (Button btn in btns) // Paras tapa prosessoida listoja.
        {
            btn.onClick.AddListener(() => PickAPuzzle()); // Kun klikataan korttia, se hakee funktion ja tässä tapauksessa kortin.
        }
    }

    public void PickAPuzzle() // Hakee eläinkortit.
    {
        //string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];

        } else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfThePuzzlesMatch());

          
        }
    }

    IEnumerator CheckIfThePuzzlesMatch() { // Onko kortilla pari?
        yield return new WaitForSeconds(1f);

        if(firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(.3f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        } else
        {
            yield return new WaitForSeconds(.05f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(.3f);

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished() // Onko peli läpäisty?
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses)
        {
            Debug.Log("Game Finished!");
            Debug.Log("It took you " + countGuesses + " guess(es) to finish the game");
            SceneManager.LoadScene("RoomAfterPuzzle"); // Palaa takaisin makuuhuone-sceneen, jossa ei ole mahdollisuutta enää pelata muistipeliä.
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

}