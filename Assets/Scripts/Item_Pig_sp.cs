using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_Pig_sp : MonoBehaviour
{
    public int type;
    public GameObject itemPage;
    public GameObject mask;
    //public int MaximumColorQuantity;
    [Header("一般豬的各個顏色Image")]
    public Sprite[] PigColorImages;
    [Header("水平豬的各個顏色Image")]
    public Sprite[] HorPigColorImages;
    [Header("垂直豬的各個顏色Image")]
    public Sprite[] VerPigColorImages;
    [Header("游泳圈豬的各個顏色Image")]
    public Sprite[] BombPigColorImages;
    [Header("忍者豬的各個顏色Image")]
    public Sprite[] MarmaladePigColorImages;

    public int color;
    public bool onSelect = false;

    void Start()
    {
        itemPage = GameObject.FindGameObjectWithTag("Item_Page");
        PigColorImages = itemPage.GetComponent<Item_Page_sp>().PigColorImages;
        HorPigColorImages = itemPage.GetComponent<Item_Page_sp>().HorPigColorImages;
        VerPigColorImages = itemPage.GetComponent<Item_Page_sp>().VerPigColorImages;
        BombPigColorImages = itemPage.GetComponent<Item_Page_sp>().BombPigColorImages;
        MarmaladePigColorImages = itemPage.GetComponent<Item_Page_sp>().MarmaladePigColorImages;
    }
    
    void Update()
    {
        
    }

    public void ChangeColor(int c)
    {
        if (type == 0)
        {
            this.gameObject.GetComponent<Image>().sprite = PigColorImages[c];
        }
        else if(type == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = VerPigColorImages[c];
        }
        else if(type == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = HorPigColorImages[c];
        }
        else if(type == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = BombPigColorImages[c];
        }
        else if (type == 11)
        {
            this.gameObject.GetComponent<Image>().sprite = MarmaladePigColorImages[c];
        }
        color = c;
    }

    public void SelectPig()
    {
        if(onSelect)
        {
            mask.SetActive(false);
            itemPage.GetComponent<Item_Page_sp>().selectBuffObj = null;
        }
        else
        {
            mask.SetActive(true);
            itemPage.GetComponent<Item_Page_sp>().SwitchPig(this.gameObject);
        }
        onSelect = !onSelect;
    }
}
