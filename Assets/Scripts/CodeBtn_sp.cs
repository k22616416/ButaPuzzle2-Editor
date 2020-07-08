using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeBtn_sp : MonoBehaviour
{
    public GameObject decodeBtn;
    public TMP_Text displayText;
    public TMP_InputField consoleObj;
    public Scrollbar bar;
    public GameObject[] butaObj;
    public bool consoleStatus = false;
    public LevelInfo_sp level;
    string newLine = "\r\n";
    void Start()
    {
        displayText = this.transform.GetChild(0).GetComponent<TMP_Text>();
    }

    
    void Update()
    {
        
    }

    public IEnumerator FineButaObject()
    {
        while(!(consoleStatus))
        {
            if (butaObj.Length != GameObject.FindGameObjectsWithTag("Buta").Length)
            {
                butaObj = new GameObject[GameObject.FindGameObjectsWithTag("Buta").Length];
                int index = 0;
                foreach (GameObject g in GameObject.FindGameObjectsWithTag("Buta"))
                {
                    butaObj[index] = g;
                    index++;
                    yield return new WaitForSeconds(0.3f);
                }
            }
            
        
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator CodeingString()
    {
        //LevelInfo_sp level = GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<LevelInfo_sp>();
        consoleObj.text = "";
        consoleObj.text += string.Format("MODE {0}",level.target.type) + newLine;
        consoleObj.text += string.Format("SIZE {0}/{1}",level.col,level.row) + newLine;
        consoleObj.text += string.Format("LIMIT {0}/{1}",level.limit.type,level.limit.step) + newLine;
        consoleObj.text += string.Format("COLOR LIMIT {0}",level.colorLimit) + newLine;
        consoleObj.text += string.Format("STARS {0}/{1}/{2}",level.stars.star1,level.stars.star2,level.stars.star3) + newLine;
        if(level.target.type == (int)LevelInfo_sp.TargetTypes.CollectTheItems || level.target.type == (int)LevelInfo_sp.TargetTypes.FallDownThePig)
        {
            consoleObj.text += string.Format("COLLECT ITEMS 1/2") + newLine;
        }
        else
        {
            consoleObj.text += string.Format("COLLECT ITEMS 0/0") + newLine;
        }
        consoleObj.text += string.Format("COLLECT COUNT {0}/{1}",level.target.collect[0], level.target.collect[1]);
        consoleObj.text += newLine;
        //consoleObj.text += newLine;

        yield return new WaitForSeconds(0.1f);

        if (butaObj.Length != GameObject.FindGameObjectsWithTag("Buta").Length)
        {
            butaObj = new GameObject[GameObject.FindGameObjectsWithTag("Buta").Length];
            int index = 0;
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Buta"))
            {
                butaObj[index] = g;
                index++;
            }
        }

        List<int> portalLen = new List<int>();
        for(int i=0,index = 1;i<butaObj.Length;i++,index++)
        {
            consoleObj.text += butaObj[i].GetComponent<Buta_sp>().butaString.Output();
            if(level.col == index)
            {
                consoleObj.text += newLine;
                index = 0;
            }
            else
            {
                consoleObj.text += " ";
            }

            if (butaObj[i].GetComponent<Buta_sp>().hasPortalIn)
                portalLen.Add(i);
            yield return new WaitForSeconds(0.1f);
        }

        
        
        foreach(int i in portalLen)
        {
            if (butaObj[i].GetComponent<Buta_sp>().hasPortalIn)
            {
                consoleObj.text += newLine;
                consoleObj.text += String.Format("TELEPORT 0,{0},{1},{2},{3}", 
                    butaObj[i].GetComponent<Buta_sp>().location.x, 
                    butaObj[i].GetComponent<Buta_sp>().location.y, 
                    butaObj[i].GetComponent<Buta_sp>().portalTo.x, 
                    butaObj[i].GetComponent<Buta_sp>().portalTo.y
                    );
            }
                
        }



    }

    public void BtnPush()
    {
        //if (decodeBtn.GetComponent<DecodeBtn_sp>().consoleStatus)
            //return;
        consoleStatus = !consoleStatus;
        if (consoleStatus)
        {
            StartCoroutine("CodeingString");
            consoleObj.gameObject.SetActive(true);
            bar.gameObject.SetActive(true);
            displayText.text = "Close";
            decodeBtn.SetActive(false);
        }
        else
        {
            consoleObj.gameObject.SetActive(false);
            bar.gameObject.SetActive(false);
            displayText.text = "Code";
            decodeBtn.SetActive(true);
        }

    }
}
