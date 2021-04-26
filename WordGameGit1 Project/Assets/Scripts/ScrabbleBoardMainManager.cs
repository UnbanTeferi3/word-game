using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrabbleBoardMainManager : MonoBehaviour
{
    public Transform parentGameObject;
    public List<GameObject> yAxisObjectsList = new List<GameObject>();

    public GameObject letterButton;
    public GameObject yAxisObject;
    public int xAxisLength;
    public int yAxisLength;
    public GameObject[,] yXAxis2DArray;

    //convert string to string list test
    public List<string> lettersInputList = new List<string>();
    
    //to randomize letters
    public string[] alphabetArray = new string[26];
    public string[] randomizedLettersArray;
    public string randomizedLetterString;
    public ScrabbleScriptableObject scrabbleScriptableObject;

    //to populate answers
    public List<string> answersList = new List<string>();
    public List<GameObject> answerManagerObjectList = new List<GameObject>();

    

    private void Awake()
    {
        //Initialize array size
        yXAxis2DArray = new GameObject[yAxisLength, xAxisLength];
        randomizedLettersArray = new string[xAxisLength];

        scrabbleScriptableObject.RandomizeLettersInputList();
        InstantiateXAxisGrids();
        InstantiateButtons();
        PopulateChar();
        PopulateAnswers();


    }

    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {



    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    IEnumerator InstantiateWaitForSecCoroutine()
    {
        foreach (GameObject x in yXAxis2DArray)
        {
            yield return new WaitForSeconds(5);

            GameObject j = Instantiate(x, new Vector3(0, 0, 0), Quaternion.identity);
            j.transform.SetParent(parentGameObject);


        }
    }

    public void InstantiateXAxisGrids()
    {
        for (int i = yAxisLength; i > 0; i--)
        {
            GameObject j = Instantiate(yAxisObject, new Vector3(0, 0, 0), Quaternion.identity);
            
            j.transform.SetParent(parentGameObject);
            j.transform.localScale = Vector3.one;
            yAxisObjectsList.Add(j);
        }
    }

    public void InstantiateButtons()
    {

        for (int y = 0; y < yAxisLength; y++)
        {
            for (int x = 0; x < xAxisLength; x++)
            {
                GameObject j = Instantiate(letterButton, new Vector3(0, 0, 0), Quaternion.identity);
                //j.transform.SetParent(parentGameObject);
                j.transform.SetParent(yAxisObjectsList[y].transform);
                j.transform.localScale = Vector3.one;
                //j.GetComponent<LetterButtonManager>().selectedAsAnswer = true;



                // assign gameobject to 2D array matrix
                yXAxis2DArray[y, x] = j;


            }
        }

    }

    #region Randomize and populate x axis with letters methods

    public void PopulateChar()
    {

        //RandomizeLettersInputList();

        for (int y = 0; y < yAxisLength; y++)
        {


            //char[] charArr = lettersInputList[y].ToCharArray();
            char[] charArr = scrabbleScriptableObject.lettersInputListContainer[y].ToCharArray();


            for (int x = 0; x < xAxisLength; x++)
                {
                    

                    yXAxis2DArray[y, x].GetComponentInChildren<Text>().text = charArr[x].ToString();
                    //horizontalList[i].gameObject.GetComponentInChildren<Text>().text = charArr[i].ToString();
                    //horizontalList[i].gameObject.GetComponentInChildren<Text>().text = letterList[i];

                }
              
        }
     

    }

    public void RandomizeLetters()
    {

        for (int i = 0; i<15; i++)
        {

            randomizedLettersArray[i] = alphabetArray[Random.Range(0, 25)];

        }

        randomizedLetterString = string.Concat(randomizedLettersArray);
    }

    //call this function to randomize somewhere else (not automatic)
    public void RandomizeLettersInputList()
    {

        for (int y = 0; y < yAxisLength; y++)
        {
            RandomizeLetters();
            //lettersInputList[y] = randomizedLetterString;
            scrabbleScriptableObject.lettersInputListContainer[y] = randomizedLetterString;
            //ScrabbleScriptableObject.

        }

    }

    #endregion

    #region Populate answers into grid methods

    //int charLength = 0;
    public int[] coordArray = new int[2];
    public int orientationProbability = 0; //using int as boolean to create a 50 percent chance probability method
    public string currentString;
    public bool pathIsClear = false; //default is true because will be checked if all elements are true in an array/list
    public bool pathIsEmpty = false;
    public bool answerPopulated = false;// flag to make sure answers can only be populated once(prevent infinite loop)

    public void PopulateAnswers()
    {
        //guard clause checks answerPopulated flag
        if(answerPopulated == true)
        {

            return;

        }

        // randomize the position of the first letter of each answer inside the grid
        for (int i = 0; i < answersList.Count; i++)
        {

            char[] charArr = answersList[i].ToCharArray();
            //charLength = charArr.Length;
            orientationProbability = Random.Range(0, 2);
            IsPathClear(answersList[i]);
            IsPathEmpty(answersList[i]);

            //check if path clear
            if (pathIsEmpty == true)
            {
                //char[] charArr = scrabbleScriptableObject.lettersInputListContainer[y].ToCharArray();

                if (orientationProbability == 0)
                {
                    for (int y = 0; y < answersList[i].Length; y++)
                    {

                        yXAxis2DArray[coordArray[0] + y, coordArray[1]].GetComponentInChildren<Text>().text = charArr[y].ToString();
                        //yXAxis2DArray[coordArray[0] + y, coordArray[1]].GetComponent<Image>().color = Color.blue;
                        yXAxis2DArray[coordArray[0] + y, coordArray[1]].GetComponent<LetterButtonManager>().selectedAsAnswer = true;

                        //send answer button coords to LetterButtonManager
                        answerManagerObjectList[i].GetComponent<ScrabbleAnswerManager>().answerList.Add(yXAxis2DArray[coordArray[0] + y, coordArray[1]]);
                        


                    }

                    //foreach (gameObject i answerManagerObjectList[i].GetComponent<ScrabbleAnswerManager>().answerList[i].

                    answerManagerObjectList[i].GetComponent<ScrabbleAnswerManager>().AddCheckAnswerMethodToList();


                }
                else if(orientationProbability == 1)
                {

                    for (int x = 0; x < answersList[i].Length; x++)
                    {
                        yXAxis2DArray[coordArray[0], coordArray[1] + x].GetComponentInChildren<Text>().text = charArr[x].ToString();
                        //yXAxis2DArray[coordArray[0], coordArray[1] + x].GetComponent<Image>().color = Color.blue;
                        yXAxis2DArray[coordArray[0], coordArray[1] + x].GetComponent<LetterButtonManager>().selectedAsAnswer = true;


                        answerManagerObjectList[i].GetComponent<ScrabbleAnswerManager>().answerList.Add(yXAxis2DArray[coordArray[0], coordArray[1] + x]);

                    }

                    answerManagerObjectList[i].GetComponent<ScrabbleAnswerManager>().AddCheckAnswerMethodToList();

                }
                
            }
            if(pathIsEmpty == false)
            {
                Debug.Log("Populate answers stopped");
                i -= 1;
                //break;
            }

        }

        answerPopulated = true;

    }

    public void ChooseStartPosition()
    {
        

        coordArray[0] = Random.Range(0, yAxisLength);

        coordArray[1] = Random.Range(0, xAxisLength);

    }

    public void IsPathClear(string pathString)
    {
        currentString = pathString;
        ChooseStartPosition();
        //orientationProbability = Random.Range(0, 2);

        if(orientationProbability == 0)
        {

            pathIsClear = true;

            for (int y = coordArray[0]; y < (coordArray[0] + currentString.Length); y++)
            {

                if (y >= yAxisLength)
                {
                    pathIsClear = false;
                    Debug.Log("y path is not clear");
                    break;


                }

            }

            

        }
        else if(orientationProbability == 1)
        {
            pathIsClear = true;

            for (int x = coordArray[1]; x < (coordArray[1] + currentString.Length); x++)
            {

                if(x >= xAxisLength)
                {

                    pathIsClear = false;
                    Debug.Log("x path is not clear");
                    break;


                }



            }

            

        }
        
        

            //return true;




    }

    public void IsPathEmpty(string pathString)
    {
        
        if (pathIsClear == true)
        {

            char[] charArr = pathString.ToCharArray();

            if (orientationProbability == 0)
            {

                pathIsEmpty = true;

                for (int y = 0; y < pathString.Length; y++)
                {
                    //checks if button hasn't already been populated and if the button to populate doesn't have the same letter
                    if (yXAxis2DArray[coordArray[0] + y, coordArray[1]].GetComponent<LetterButtonManager>().selectedAsAnswer == true && yXAxis2DArray[coordArray[0] + y, coordArray[1]].GetComponentInChildren<Text>().text != charArr[y].ToString())
                    {
                        Debug.Log("Y path is used");
                        pathIsEmpty = false;
                        break;


                    }

                }

            }
            else if (orientationProbability == 1)
            {

                pathIsEmpty = true;

                for (int x = 0; x < pathString.Length; x++)
                {
                    if (yXAxis2DArray[coordArray[0], coordArray[1] + x].GetComponent<LetterButtonManager>().selectedAsAnswer == true && yXAxis2DArray[coordArray[0], coordArray[1] + x].GetComponentInChildren<Text>().text != charArr[x].ToString())
                    {
                        Debug.Log("X path is used");
                        pathIsEmpty = false;
                        break;


                    }

                }

            }

        }
        else if(pathIsClear == false)
        {
            pathIsEmpty = false;
            Debug.Log("Path is not clear");
            return;

        }


    }



    #endregion
}
