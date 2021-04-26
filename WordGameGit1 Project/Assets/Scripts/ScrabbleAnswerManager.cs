using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrabbleAnswerManager : MonoBehaviour
{
    //public bool 

    public List<GameObject> answerList = new List<GameObject>();
    //public List<GameObject> boxList = new List<GameObject>();
    //public List<string> answerIndexList = new List<string>();
    public GameObject boardBuilderObject;
    //public int numberOfBoxList;
    public List<int> letterCoordY;
    public List<int> letterCoordX;


    //for checking if button is the target color
    public Color targetColor;
    public bool allTrue = false;

    //public List<bool> isSelected = new List<bool>();

    //for scoreboard
    //public int score = 0;
    //public Text scoreText;
    public GameObject scoreObject;

    //to disable checkAnswer
    public bool isAnswered = false;

    //public List<string> answerListString = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        /*
        PopulateAnswerList();
        foreach (GameObject i in answerList)
        {
            //onClick.Addlistener adds method to button via code
            i.GetComponent<Button>().onClick.AddListener(CheckAnswer);

            
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool IsBlue(GameObject c)
    {
        if (c.GetComponent<Image>().color == targetColor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AnswerCorrect()
    {



        //this.gameObject.GetComponentsInChildren<Image>().enabled = false;
        Transform[] children = new Transform[this.gameObject.transform.childCount];
        for (int i = 0; i < children.Length; i++)
        {
            //children[i] = transform.GetChild(i);
            if (transform.GetChild(i).gameObject.GetComponent<Image>() != null)
            {
                transform.GetChild(i).gameObject.GetComponent<Image>().enabled = false;
            }
            
        }

        this.gameObject.GetComponent<AudioSource>().Play();
            
    }

    public void CheckAnswer()
    {
        if (isAnswered == false)
        {
            //check if all objects passed thru method IsBlue is true
            allTrue = answerList.TrueForAll(IsBlue);

            if (allTrue == true)
            {
                scoreObject.GetComponent<ScrabbleScore>().score += 1;
                ScrabbleSingleton.SS.finalScore += 1;
                //scoreObject.GetComponent<ScrabbleScore>().scoreText.text = scoreObject.GetComponent<ScrabbleScore>().score + "/8";
                //this.gameObject.GetComponent<Image>().color = Color.blue; //method to affect answer images and playing chimes should go here
                AnswerCorrect();
                foreach(GameObject x in answerList)
                {
                    x.GetComponent<Button>().enabled = false;
                }
                isAnswered = true;
            }

            

        }
        

        //if ()

        /*
        bool[] isSelected = new bool[answerList.Count];
        for (int i = 0; i < answerList.Count; i++)
        {
            isSelected[i] = false;
        }
        */

        //if(answerList.Contains())
        

        
        /*
        for (int i = 0; i < answerList.Count; i++)
        {
            if (answerList[i] != EventSystem.current.currentSelectedGameObject)
            {

                if (answerList[i].GetComponent<Image>().color == Color.blue)
                {
                    bool newBool = true;
                    isSelected.Add(newBool);
                }

            }
        }

        for (int j = 0; j < answerList.Count; j++)
        {
            if (isSelected[j] == false)
            {

                allTrue = true;
                break;

            }
        }
        */








        //Debug.Log("Answer button clicked!!!");


    }

    

    
    public void PopulateAnswerList()
    {
        /*
        for (int i = boxList.Count; i>0; i--)
        {
            answerList.Add(boxList[i].GetComponent<ScrabbleBoardBuilder>().horizontalList[i]);
        }
        */

        for (int i = 0; i< letterCoordY.Count; i++)
        {

            answerList.Add(boardBuilderObject.GetComponent<ScrabbleBoardMainManager>().yXAxis2DArray[letterCoordY[i], letterCoordX[i]]);




        }

        


    }

    public void AddCheckAnswerMethodToList()
    {

        foreach (GameObject i in answerList)
        {
            //onClick.Addlistener adds method to button via code
            i.GetComponent<Button>().onClick.AddListener(CheckAnswer);


        }

    }
    
}
