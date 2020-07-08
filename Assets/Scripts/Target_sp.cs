using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Target_sp : MonoBehaviour
{
    public Button targetSwitch;
    public TMP_InputField[] collect;
    public int[] collectValue = new int[2];
    public int mode = 0;
    public void BtnPush()
    {
        
        if (mode < (int)LevelInfo_sp.TargetTypes.Length-1)
        {
            mode++;
        }
        else
            mode=0;
        if(mode == (int)LevelInfo_sp.TargetTypes.CollectTheItems || mode == (int)LevelInfo_sp.TargetTypes.FallDownThePig)
        {
            collect[0].gameObject.SetActive(true);
            collect[1].gameObject.SetActive(true);
        }
        else
        {
            collect[0].gameObject.SetActive(false);
            collect[1].gameObject.SetActive(false);
        }
        targetSwitch.transform.GetChild(0).GetComponent<Text>().text = Enum.GetName(typeof(LevelInfo_sp.TargetTypes),mode);
        
    }

    void Update()
    {
        if(collect[0].text != "")
            collectValue[0] = int.Parse(collect[0].text);
        if(collect[1].text != "")
            collectValue[1] = int.Parse(collect[1].text);
    }

    public int[] GetCollects()
    {
        int[] v = new int[2];
        v[0] = int.Parse(collect[0].text.ToString());
        v[1] = int.Parse(collect[1].text.ToString());
        return v;
    }
}
