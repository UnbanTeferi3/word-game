using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text timer;
    //public TextMesh timer;
    float minutes = 5;
    float seconds = 0;
    float miliseconds = 0;

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

        }


        

        //Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
        timer.text = string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds);
    }
}
