using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrabbleRestart : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadCurrentScene()
    {
        ScrabbleSingleton.SS.finalScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
