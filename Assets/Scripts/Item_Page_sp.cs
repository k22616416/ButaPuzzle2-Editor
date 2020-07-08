using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_Page_sp : MonoBehaviour
{

    public GameObject[] itemPig;
    public GameObject[] itemBuff;
    public GameObject selectPigObj;
    public int selectPigType
    {
        get
        {
            return selectPigObj.GetComponent<Item_Pig_sp>().type;
        }
    }
    public GameObject selectBuffObj;
    public int selectBuffType
    {
        get
        {
            return selectBuffObj.GetComponent<Item_sp>().buffType;
        }
    }
    public int color;
    [Header("豬的顏色數量")]
    public int MaximumColorQuantity;
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


    bool init = false;

    void Start()
    {
        StartCoroutine("PageInit");
        init = true;
    }
    
    void Update()
    {
        
    }

    public IEnumerator PageInit()
    {
        while (!(init))
            yield return new WaitForSeconds(0.5f);

        int pigIndex = 0, buffIndex = 0;
        for (int i = 0; i < this.gameObject.transform.childCount; i++) 
        {
            if (this.gameObject.transform.GetChild(i).tag == "Item_Pig")
            {
                pigIndex++;
            }
            else if(this.gameObject.transform.GetChild(i).tag == "Item_Buff")
            {
                buffIndex++;
            }
        }
        itemPig = new GameObject[pigIndex];
        itemBuff = new GameObject[buffIndex];
        for (int i = 0,index1=0 ,index2=0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).tag == "Item_Pig")
            {
                itemPig[index1] = this.gameObject.transform.GetChild(i).gameObject;
                index1++;
            }
            else if (this.gameObject.transform.GetChild(i).tag == "Item_Buff")
            {
                itemBuff[index2] = this.gameObject.transform.GetChild(i).gameObject;
                index2++;
            }
        }
    }

    public void SwitchPig(GameObject obj)
    {
        for (int i = 0; i < itemPig.Length; i++)
        {
            if (itemPig[i] != obj && itemPig[i].GetComponent<Item_Pig_sp>().onSelect)
                itemPig[i].GetComponent<Item_Pig_sp>().SelectPig();
        }
        selectPigObj = obj;
        color = obj.GetComponent<Item_Pig_sp>().color;
    }

    public void SelectBuff(GameObject buffType)
    {
        for (int i = 0; i < itemBuff.Length; i++)
        {
            if (itemBuff[i] != buffType && itemBuff[i].GetComponent<Item_sp>().onSelect)
                itemBuff[i].GetComponent<Item_sp>().AddBuff();
        }
        selectBuffObj = buffType;
    }

    public void ClearSelect()
    {
        for (int i = 0; i < itemPig.Length; i++)
        {
            if (itemPig[i].GetComponent<Item_Pig_sp>().onSelect)
                itemPig[i].GetComponent<Item_Pig_sp>().SelectPig();
        }
        for (int i = 0; i < itemBuff.Length; i++)
        {
            if (itemBuff[i].GetComponent<Item_sp>().onSelect)
                itemBuff[i].GetComponent<Item_sp>().AddBuff();
        }
        selectBuffObj = selectPigObj = null;
    }
}
