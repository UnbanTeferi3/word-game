using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton S;

    public int testValue;

    private void OnEnable()
    {
        
        if(Singleton.S == null)
        {

            Singleton.S = this;

        }
        else if (Singleton.S != this)
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
        
    }
}
