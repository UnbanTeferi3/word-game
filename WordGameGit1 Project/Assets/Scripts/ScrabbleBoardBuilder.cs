using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrabbleBoardBuilder : MonoBehaviour
{
    
    public Transform parentGameObject;
    
    public List<GameObject> horizontalList = new List<GameObject>();
    public List<string> letterList = new List<string>();
    
    public GameObject letterButton;
    public int buttonsAmount;

    //convert string to string list test
    public string lettersInput;
    //public List<string> lettersInputList = new List<string>();
    

    private void Awake()
    {

        if (horizontalList != null)
        {

            InstantiateButtons();
            PopulateChar();




            //StartCoroutine(InstantiateWaitForSecCoroutine());
        }

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
        foreach (GameObject x in horizontalList)
        {
            yield return new WaitForSeconds(5);

            GameObject j = Instantiate(x, new Vector3(0,0,0) , Quaternion.identity);
            j.transform.SetParent(parentGameObject);
            
            
        }   
    }

    

    public void InstantiateButtons()
    {
        for (int i = buttonsAmount; i > 0; i--)
        {
            GameObject j = Instantiate(letterButton, new Vector3(0, 0, 0), Quaternion.identity);
            j.transform.SetParent(parentGameObject);
            horizontalList.Add(j);
        }
    }

    public void PopulateChar()
    {
        char[] charArr = lettersInput.ToCharArray();

        for (int i=0;i<15; i++ )
        {

            horizontalList[i].gameObject.GetComponentInChildren<Text>().text = charArr[i].ToString();
            //horizontalList[i].gameObject.GetComponentInChildren<Text>().text = letterList[i];

        }
    }
}
