using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAudioPrefab : MonoBehaviour
{
    //for audio
    public GameObject buttonClickAudioObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateAudioPrefabMethod()
    {

        GameObject audioObject = Instantiate(buttonClickAudioObject, new Vector3(0, 0, 0), Quaternion.identity);

    }
}
