using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Space_Page_sp : MonoBehaviour
{
    public GameObject[] spaceObjs;
    public GameObject onSelect;
    public int selectSpaceType = -1;
    void Start()
    {
        StartCoroutine("init");
    }
    
    void Update()
    {
        
    }

    public IEnumerator init()
    {
        int index = 0;
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).tag == "Space")
                index++;
        }
        yield return new WaitForSeconds(0.2f);
        spaceObjs = new GameObject[index];
        spaceObjs = GameObject.FindGameObjectsWithTag("Space");
        
    }

    public void SelectObj(GameObject obj)
    {
        for (int i = 0; i < spaceObjs.Length; i++) 
        {
            if (spaceObjs[i] != obj && spaceObjs[i].gameObject.GetComponent<Space_sp>().onSelect)
                spaceObjs[i].gameObject.GetComponent<Space_sp>().BtnPush();
        }
        onSelect = obj;
        
    }
}
