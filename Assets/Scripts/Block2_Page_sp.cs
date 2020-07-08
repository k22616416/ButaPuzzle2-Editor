using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Block2_Page_sp : MonoBehaviour
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
        int totleObj = 0;
        for (int index = 0; index < this.gameObject.transform.childCount; index++)
        {
            if (this.gameObject.transform.GetChild(index).transform.tag == "Block2")
            {
                totleObj++;
            }
        }
        blocks = new Button[totleObj];
        for (int i = 0, index = 0; i < this.gameObject.transform.childCount; i++, index++)
        {
            if (this.gameObject.transform.GetChild(i).transform.tag == "Block2")
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
            if (blocks[i].gameObject.transform.tag == "Block2")
                if (blocks[i].gameObject != obj && blocks[i].gameObject.GetComponent<Block2_sp>().onSelect)
                {
                    blocks[i].GetComponent<Block2_sp>().BtnPush();
                }

        }
        selectObj = obj;
        SAKU = obj.GetComponent<Block2_sp>().SAKU;
        OBS = obj.GetComponent<Block2_sp>().OBS;
        DIR = obj.GetComponent<Block2_sp>().DIR;
        SOURCE = obj.GetComponent<Block2_sp>().SOURCE;
        COLOR = obj.GetComponent<Block2_sp>().COLOR;
        ITEM_TYPE = obj.GetComponent<Block2_sp>().ITEM_TYPE;
        BLOCK2 = obj.GetComponent<Block2_sp>().BLOCK2;
        ITEM_CONDITION = obj.GetComponent<Block2_sp>().ITEM_CONDITION;

        blockID = obj.GetComponent<Block2_sp>().ID;
    }
}
