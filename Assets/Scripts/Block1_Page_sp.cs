using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Block1_Page_sp : MonoBehaviour
{
    public Button[] blocks;
    //public Button onSelect;
    public int blockID;
    public GameObject selectObj;
    
    public bool SAKU;
    public bool OBS;
    public bool DIR;
    public bool SOURCE;
    public bool COLOR;
    public bool ITEM_TYPE;
    public bool BLOCK2;
    public bool ITEM_CONDITION;

    bool init = false;
    void Start()
    {
        StartCoroutine("Blocks_init");
        init = true;
    }

    
    void Update()
    {
        
    }

    public IEnumerator Blocks_init()
    {
        while (!(init))
            yield return new WaitForSeconds(0.5f);
        //blocks = new Button[this.gameObject.transform.childCount];
        int totleObj = 0;
        for (int index = 0; index < this.gameObject.transform.childCount; index++)
        {
            if (this.gameObject.transform.GetChild(index).transform.tag == "Block1")
            {
                totleObj++;
            }
        }
        blocks = new Button[totleObj];
        for (int i = 0, index = 0; i < this.gameObject.transform.childCount; i++, index++)   
        {
            if (this.gameObject.transform.GetChild(i).transform.tag == "Block1")
            {
                blocks[index] = this.gameObject.transform.GetChild(i).GetComponent<Button>();
            }
            else
                index--;
            
        }

    }

    public void SelectBlockObj(GameObject obj)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if(blocks[i].gameObject.transform.tag == "Block1")
                if (blocks[i].gameObject != obj && blocks[i].gameObject.GetComponent<Block1_sp>().onSelect)
                {
                    blocks[i].GetComponent<Block1_sp>().BtnPush();
                }
                    
        }
        SAKU = obj.GetComponent<Block1_sp>().SAKU;
        OBS = obj.GetComponent<Block1_sp>().OBS;
        DIR = obj.GetComponent<Block1_sp>().DIR;
        SOURCE = obj.GetComponent<Block1_sp>().SOURCE;
        COLOR = obj.GetComponent<Block1_sp>().COLOR;
        ITEM_TYPE = obj.GetComponent<Block1_sp>().ITEM_TYPE;
        BLOCK2 = obj.GetComponent<Block1_sp>().BLOCK2;
        ITEM_CONDITION = obj.GetComponent<Block1_sp>().ITEM_CONDITION;
        
        selectObj = obj;
        blockID = obj.GetComponent<Block1_sp>().ID;
    }
}
