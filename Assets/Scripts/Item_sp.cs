using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Item_sp : MonoBehaviour
{
    public bool hasSource;
    public int buffType;
    public int MaximumColorQuantity;
    public int nowColor = 0;
    public GameObject[] pigObjs;
    public GameObject mask;
    public GameObject itemPageObj;

    public bool onSelect = false;
    void Start()
    {
        if(hasSource)
        {
            itemPageObj = GameObject.FindGameObjectWithTag("Source_Page");
            MaximumColorQuantity = itemPageObj.GetComponent<Item_Page_sp>().MaximumColorQuantity;
        }
        else
        {
            itemPageObj = GameObject.FindGameObjectWithTag("Item_Page");
            MaximumColorQuantity = itemPageObj.GetComponent<Item_Page_sp>().MaximumColorQuantity;
        }
            
    }
    
    void Update()
    {
        
    }

    public void ColorChange()
    {
        if (nowColor < MaximumColorQuantity-1)
            nowColor++;
        else
            nowColor = 0;
        itemPageObj.GetComponent<Item_Page_sp>().color = nowColor;
        for (int i = 0; i < pigObjs.Length; i++) 
        {
            pigObjs[i].GetComponent<Item_Pig_sp>().ChangeColor(nowColor);
        }
    }
    public void AddBuff()
    {
        if(onSelect)
        {
            mask.SetActive(false);
            itemPageObj.GetComponent<Item_Page_sp>().selectBuffObj = null;
        }
        else
        {
            mask.SetActive(true);
            itemPageObj.GetComponent<Item_Page_sp>().SelectBuff(this.gameObject);
        }
        onSelect = !onSelect;
    }

    
    
}
