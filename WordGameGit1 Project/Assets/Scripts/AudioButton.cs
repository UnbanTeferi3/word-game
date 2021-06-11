﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public bool audioON = false;
    public Image buttonImage;
    public Sprite audioOnIMG;
    public Sprite audioOffIMG;
    public GameObject cameraGO;

    private void Awake()
    {
        
        if (buttonImage == null)
        {
            buttonImage = GameObject.FindGameObjectWithTag("AudioButton").GetComponent<Image>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        buttonImage.gameObject.GetComponent<Button>().onClick.AddListener(OnClickAudioButton);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(buttonImage == null)
        {
            buttonImage = GameObject.FindGameObjectWithTag("AudioButton").GetComponent<Image>();

            if (audioON == true)
            {
                buttonImage.sprite = audioOnIMG;
            }
            else if (audioON == false)
            {
                buttonImage.sprite = audioOffIMG;
            }

            buttonImage.gameObject.GetComponent<Button>().onClick.AddListener(OnClickAudioButton);
        }
        
    }

    public void OnClickAudioButton()
    {

        if(audioON == false)
        {
            buttonImage.sprite = audioOnIMG;
            cameraGO.GetComponent<AudioListener>().enabled = true;
            audioON = true;

        }
        else if (audioON == true)
        {
            buttonImage.sprite = audioOffIMG;
            cameraGO.GetComponent<AudioListener>().enabled = false;
            audioON = false;
        }

    }
}