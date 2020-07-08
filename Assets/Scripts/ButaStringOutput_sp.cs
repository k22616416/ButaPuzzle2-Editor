using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButaStringOutput_sp : MonoBehaviour
{
    public TMP_Text srtingObj;
    public Block1_Page_sp block1;
    public Block2_Page_sp block2;
    public Item_Page_sp item;
    public Item_Page_sp source;
    public const string title = "ButaString:";

    public class OutputStr
    {

        public int saku;
        public int obs;
        public int dir;
        public int source;
        public int color;
        public int itemType;
        public int block2;
        public int itemCoudition;
        public string Output()
        {
            return saku.ToString() + ","
                + obs.ToString() + ","
                + dir.ToString() + ","
                + source.ToString() + ","
                + color.ToString() + ","
                + itemType.ToString() + ","
                + block2.ToString() + ","
                + itemCoudition.ToString();
        }
        public void Clear()
        {
            saku = obs = dir = source = color = itemType = block2 = itemCoudition = 0;
        }
    };
    public OutputStr str = new OutputStr();

    void Start()
    {
        srtingObj = this.gameObject.GetComponent<TMP_Text>();
        srtingObj.text = title;
    }

    
    void Update()
    {
        
    }

    public void Add()
    {
        if(block1.gameObject.activeSelf)
        {
            if (block1.SAKU) str.saku = block1.blockID;
            else if (block1.OBS) str.obs = block1.blockID;
            else if (block1.DIR) str.dir = block1.blockID;
            else if (block1.SOURCE) str.source = block1.blockID;
            else if (block1.COLOR) str.color = block1.blockID;
            else if (block1.ITEM_TYPE) str.itemType = block1.blockID;
            else if (block1.BLOCK2) str.block2 = block1.blockID;
            else if (block1.ITEM_CONDITION) str.itemCoudition = block1.blockID;
            srtingObj.text = title + str.Output();
        }
        else if(block2.gameObject.activeSelf)
        {
            if (block2.SAKU) str.saku = block2.blockID;
            else if (block2.OBS) str.obs = block2.blockID;
            else if (block2.DIR) str.dir = block2.blockID;
            else if (block2.SOURCE) str.source = block2.blockID;
            else if (block2.COLOR) str.color = block2.blockID;
            else if (block2.ITEM_TYPE) str.itemType = block2.blockID;
            else if (block2.BLOCK2) str.block2 = block2.blockID;
            else if (block2.ITEM_CONDITION) str.itemCoudition = block2.blockID;
            srtingObj.text = title + str.Output();
        }
        else if(item.gameObject.activeSelf)
        {
            if(item.selectPigObj != null)
            {
                str.itemType = item.selectPigType;
                if(item.selectBuffObj != null)
                    str.itemCoudition = item.selectBuffType;
            }
            srtingObj.text = title + str.Output();

        }
        else if(source.gameObject.activeSelf)
        {
            if(source.selectBuffObj != null)
            {
                str.source = source.selectBuffType;
            }
            srtingObj.text = title + str.Output();
        }
        
    }
}
