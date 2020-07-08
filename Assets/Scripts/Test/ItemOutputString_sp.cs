using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class ItemOutputString_sp : MonoBehaviour
{
    public GameObject Block1Page;
    public GameObject Block2Page;
    public GameObject itemPage;
    public GameObject SourcePage;
    public GameObject SpacePage;
    //public string format = "0,0,0,0,0,0,0,0";
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
    OutputStr str = new OutputStr();
    

    void Start()
    {

    }
    
    void Update()
    {
        if(Block1Page != null)
            if (Block1Page.activeSelf)
                Block1PageSet();
        if(Block2Page != null)
            if (Block2Page.activeSelf)
                Block2PageSet();
        if (itemPage != null)
            if (itemPage.activeSelf)
                ItemPageSet();
        if (SourcePage != null)
            if (SourcePage.activeSelf)
                SourcePageSet();

        this.GetComponent<TMP_Text>().text = str.Output();
        
    }

    void Block1PageSet()
    {
        Block1_Page_sp sp = Block1Page.GetComponent<Block1_Page_sp>();
        str.Clear();
        if (sp.selectObj != null)
        {
            
            int ID = sp.selectObj.GetComponent<Block1_sp>().ID;
            if (sp.SAKU) str.saku = ID;
            else if (sp.OBS) str.obs = ID;
            else if (sp.DIR) str.dir = ID;
            else if (sp.SOURCE) str.source = ID;
            else if (sp.COLOR) str.color = ID;
            else if (sp.ITEM_TYPE) str.itemType = ID;
            else if (sp.BLOCK2) str.block2 = ID;
            else if (sp.ITEM_CONDITION) str.itemCoudition = ID;
        }
    }

    void Block2PageSet()
    {
        Block2_Page_sp sp = Block2Page.GetComponent<Block2_Page_sp>();
        str.Clear();
        if (sp.selectObj != null)
        {
            
            int ID = sp.selectObj.GetComponent<Block2_sp>().ID;
            if (sp.SAKU) str.saku = ID;
            else if (sp.OBS) str.obs = ID;
            else if (sp.DIR) str.dir = ID;
            else if (sp.SOURCE) str.source = ID;
            else if (sp.COLOR) str.color = ID;
            else if (sp.ITEM_TYPE) str.itemType = ID;
            else if (sp.BLOCK2) str.block2 = ID;
            else if (sp.ITEM_CONDITION) str.itemCoudition = ID;
        }
    }

    void ItemPageSet()
    {
        Item_Page_sp sp = itemPage.GetComponent<Item_Page_sp>();
        str.Clear();
        if (sp.selectPigObj != null)
        {

            str.itemType = sp.selectPigType;
            if(sp.selectBuffObj != null)
                str.itemCoudition = sp.selectBuffType;
        }
        /*
        else
        {
            if (sp.selectBuffObj != null)
                str.source = sp.selectBuffType;
            
        }
        */
            
    }

    void SourcePageSet()
    {
        Item_Page_sp sp = SourcePage.GetComponent<Item_Page_sp>();
        str.Clear();
        if (sp.selectBuffObj != null)
            str.source = sp.selectBuffType;
            
        
        
    }
}
