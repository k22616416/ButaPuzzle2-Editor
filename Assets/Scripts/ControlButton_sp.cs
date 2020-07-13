using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlButton_sp : MonoBehaviour
{
    public Button right;
    public Button left;
    public GameObject[] SettingPage;
    public int pagePos = 0;
    public GameObject butaTemplate;
    public GameObject gameScreenObj;
    public float butaSpacing;
    public int MaximumPageQuantity
    {
        get
        {
            return SettingPage.Length;
        }
    }
    public bool butaInit;
    void Start()
    {
        for(int i=0;i<SettingPage.Length;i++)
        {
            SettingPage[i].SetActive(false);
        }
        SettingPage[pagePos].SetActive(true);
        butaInit = false;
    }
    

    void Update()
    {
        
    }

    public void BtnPush(int btn)
    {
        if(btn == 0)    //<
        {
            pagePos--;
        }
        else
        {
            pagePos++;
        }

        if (pagePos > MaximumPageQuantity - 1)
            pagePos = 0;
        else if (pagePos < 0)
            pagePos = MaximumPageQuantity - 1;

        for (int i=0;i<MaximumPageQuantity;i++)
        {
            if (i == pagePos)
                SettingPage[i].SetActive(true);
            else
                SettingPage[i].SetActive(false);
        }
        

        if(pagePos != 0 && !butaInit)
        {
            StartCoroutine("SetGameScreen");
            butaInit = true;
        }
    }

    public IEnumerator SetGameScreen()
    {
        LevelInfo_sp level = SettingPage[0].GetComponent<LevelInfo_sp>();
        if(GameObject.FindGameObjectsWithTag("Buta").Length != 0)
        {
            foreach(GameObject i in GameObject.FindGameObjectsWithTag("Buta"))
            {
                Destroy(i);
            }
        }

        Vector3 TmpPos = butaTemplate.GetComponent<RectTransform>().localPosition;
        for(int i=0;i<level.row;i++)
        {
            
            for (int k=0;k<level.col;k++)
            {
                Vector3 pos = new Vector3(TmpPos.x + ((butaTemplate.GetComponent<RectTransform>().sizeDelta.x) + butaSpacing) * k, TmpPos.y, TmpPos.z);
                GameObject clone = Instantiate(butaTemplate, new Vector3(0,0,0), new Quaternion(), butaTemplate.transform.parent);
                clone.GetComponent<RectTransform>().localPosition = pos;
                clone.SetActive(true);
                clone.tag = "Buta";
                clone.GetComponent<Buta_sp>().location = new Vector2(k, i);
            }
            TmpPos = new Vector3(TmpPos.x, TmpPos.y - (butaTemplate.GetComponent<RectTransform>().sizeDelta.y) - butaSpacing, TmpPos.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void SetLevelSize()
    {
        butaInit = false;
        StartCoroutine("SetGameScreen");
        butaInit = true;
    }
    public void OnEndEdit(string value)
    {
        butaSpacing = float.Parse(value);
    }
}
