using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScrabbleScriptableObject", menuName = "Scriptable Objects/Scrabble")]
public class ScrabbleScriptableObject : ScriptableObject
{

    public List<string> lettersInputListContainer;
    public string[] alphabetArray = new string[26];
    public string[] randomizedLettersArray = new string[15];
    public string randomizedLetterString;
    public int yAxisLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeLettersList()
    {



    }

    public void RandomizeLetters()
    {

        for (int i = 0; i < 15; i++)
        {

            randomizedLettersArray[i] = alphabetArray[Random.Range(0, alphabetArray.Length)];

        }

        randomizedLetterString = string.Concat(randomizedLettersArray);
    }

    public void RandomizeLettersInputList()
    {

        for (int y = 0; y < yAxisLength; y++)
        {
            RandomizeLetters();
            lettersInputListContainer[y] = randomizedLetterString;

        }

    }
}
