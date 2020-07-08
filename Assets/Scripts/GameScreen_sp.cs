using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScreen_sp : MonoBehaviour
{
    public GameObject[] butaObjects;
    public GameObject ViewerPort;
    [SerializeField]
    bool busy;
    void Start()
    {
        
    }
    
    void Update()
    {
        int index = GameObject.FindGameObjectsWithTag("Buta").Length-1;
        
        if(butaObjects.Length != index && !busy)
        {
            busy = true;
            StartCoroutine("LoadButas");
        }
        
    }

    public IEnumerator LoadButas()
    {
        try
        {
            int index = 0;
            for (int i = 1; i < ViewerPort.transform.childCount; i++)
            {
                if (ViewerPort.transform.GetChild(i).tag == "Buta")
                    index++;
            }
            butaObjects = new GameObject[index];
            for (int i = 0; i < index; i++)
            {
                butaObjects[i] = ViewerPort.transform.GetChild(i+1).gameObject;
                
            }

            busy = false;
        }
        catch
        {
            busy = true;
        }
        yield return null;
    }
}
