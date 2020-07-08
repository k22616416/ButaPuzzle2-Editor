using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Limit_sp : MonoBehaviour
{
    public int type = 0;
    public Button LimitBtn;
    public int step;
    public TMP_InputField stepText;
    
    void Start()
    {
        
    }
    
    public void BtnPush()
    {
        if (type < (int)LevelInfo_sp.LimitTypes.Length - 1)
            type++;
        else
            type = 0;
        /*
        foreach(int i in Enum.GetValues(typeof(LevelInfo_sp.LimitTypes)))
        {
            if(type == i)
            {
                LimitBtn.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            }
        }*/
        
        switch(type)
        {
            case (int)LevelInfo_sp.LimitTypes.Moves:
                LimitBtn.transform.GetChild(0).GetComponent<Text>().text = LevelInfo_sp.LimitTypes.Moves.ToString();
                break;

            case (int)LevelInfo_sp.LimitTypes.Times:
                LimitBtn.transform.GetChild(0).GetComponent<Text>().text = LevelInfo_sp.LimitTypes.Times.ToString();
                break;
            /*
            default:
                type = 1;
                LimitBtn.transform.GetChild(0).GetComponent<Text>().text = LevelInfo_sp.LimitTypes.Moves.ToString();
                break;
            */
        }
        
    }

    public void OnValueChanged(string str)
    {
        step = int.Parse(str);
        
    }

}
