using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrabbleScore : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        /*
        if (finalScoreText != null)
        {
            finalScoreText.gameObject.GetComponent<Text>().color = new Color(0.18f,0.19f,0.6f,1f);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = ScrabbleSingleton.SS.finalScore + "/8";
        }
        
    }
}
