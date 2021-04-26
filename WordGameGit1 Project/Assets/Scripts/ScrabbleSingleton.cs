using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrabbleSingleton : MonoBehaviour
{
    public static ScrabbleSingleton SS;

    public int gameCount = 1;

    public int finalScore = 0;

    public GameObject gamePanelObject1;
    public GameObject gamePanelObject2;
    public GameObject gamePanelObjectParent;

    private void OnEnable()
    {

        if (ScrabbleSingleton.SS == null)
        {

            ScrabbleSingleton.SS = this;

        }
        else if (ScrabbleSingleton.SS != this)
        {

            Destroy(this.gameObject);

        }
        DontDestroyOnLoad(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gamePanelObjectParent != null)
        {
            gamePanelObjectParent = GameObject.FindGameObjectWithTag("GamingPanel");
        }
        */
        
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameCount += 1;
    }

    public void InstantiateGamePanel()
    {

        if (gameCount % 2 != 0)
        {
            GameObject j = Instantiate(gamePanelObject1, new Vector3(0, 0, 0), Quaternion.identity);
            //j.transform.SetParent(parentGameObject);
            j.transform.SetParent(gamePanelObjectParent.transform);


        }
        else if (gameCount % 2 == 0)
        {

            GameObject j = Instantiate(gamePanelObject2, new Vector3(0, 0, 0), Quaternion.identity);
            //j.transform.SetParent(parentGameObject);
            j.transform.SetParent(gamePanelObjectParent.transform);

        }

    }
}
