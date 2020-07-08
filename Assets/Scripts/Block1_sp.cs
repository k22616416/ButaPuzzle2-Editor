using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Block1_sp : MonoBehaviour
{
    public bool SAKU;
    public bool OBS;
    public bool DIR;
    public bool SOURCE;
    public bool COLOR;
    public bool ITEM_TYPE;
    public bool BLOCK2;
    public bool ITEM_CONDITION;

    public int ID;
    public bool onSelect;
    public GameObject mask;
    public GameObject block1Page;
    public Sprite blockImg
    {
        get
        {
            return this.gameObject.GetComponent<Image>().sprite;
        }
        set
        {
            this.gameObject.GetComponent<Image>().sprite = value;
        }
    }
    public Sprite[] solidImgs;
    public Sprite[] blockImgs;
    public Sprite[] wireImgs;
    
    
    void Start()
    {
        block1Page = GameObject.FindGameObjectWithTag("Block1_Page");

    }
    public void BtnPush()
    {
        onSelect = !onSelect;
        if (onSelect)
        {
            mask.SetActive(true);
            block1Page.GetComponent<Block1_Page_sp>().SelectBlockObj(this.gameObject);

            
        }
        else
        {
            mask.SetActive(false);
            if (block1Page.GetComponent<Block1_Page_sp>().selectObj == this.gameObject)
                block1Page.GetComponent<Block1_Page_sp>().selectObj = null;
            
        }
            

        

    }
}
