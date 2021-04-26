using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButtonManager : MonoBehaviour
{
    public GameObject letterButton;
    public Color targetColor;
    public bool selectedAsAnswer = false;

    

    private void Awake()
    {
        letterButton = this.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectButton()
    {
        if (letterButton == null)
        {
            return;
        }

        this.gameObject.GetComponent<AudioSource>().Play();

        if (letterButton.GetComponent<Image>().color != targetColor)
        {
            letterButton.GetComponent<Image>().color = targetColor;
            letterButton.GetComponentInChildren<Text>().color = Color.white;
        }
        else if (letterButton.GetComponent<Image>().color == targetColor)
        {
            letterButton.GetComponent<Image>().color = Color.white;
            letterButton.GetComponentInChildren<Text>().color = Color.black;
        }
        
    }
}
