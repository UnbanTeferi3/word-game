using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrabbleTimer : MonoBehaviour
{
    public Text timer;
    //public TextMesh timer;
    public float minutes = 5f;
    public float seconds = 0;
    public float miliseconds = 0;

    void Start()
    {
        //timer.text = "60";
        timer.gameObject.GetComponent<Text>().color = Color.white;
        timer.gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
    }

    void Update()
    {

        if (minutes >= 0)
        {

            if (miliseconds <= 0)
            {
                if (seconds <= 0)
                {
                    minutes--;
                    seconds = 59;
                }
                else if (seconds >= 0)
                {
                    seconds--;
                }

                miliseconds = 100;
            }

            miliseconds -= Time.deltaTime * 100;

            timer.text = "TIME: " + seconds.ToString();
            //timer.text = "TIME: " + string.Format("{0}:{1}", minutes, seconds);

        }

        else
        {
            timer.text = "TIME: 0";
            this.gameObject.GetComponent<PanelManager>().ChangePanels();
        }

        



        //Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
        //timer.text = string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds);
        
    }
}
