using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buta_sp : MonoBehaviour
{
    public Image block1;
    public Image block2;
    public Image item;
    public Image bg;
    public Image space
    {
        get
        {
            return this.GetComponent<Image>();
        }
    }
    public Block1_Page_sp block1_sp;
    public Block2_Page_sp block2_sp;
    public Item_Page_sp item_sp;
    public Item_Page_sp source_sp;
    public Space_Page_sp spacePage_sp;

    //public PageFunctionsLoad_sp imageSource;
    public FieldManagement imageSource;

    public Sprite arrowImg;
    public GameObject butaBtn;
    public bool hasPortalIn;
    public bool hasPortalOut;
    public Vector2 portalTo;

    public int spaceType;
    public int spaceDir;
    public Vector2 location = new Vector2(-1,-1);

    [System.Serializable]
    public class OutputStr
    {
        public int saku = 1;
        public int obs;
        public int dir;
        public int source = 1;
        public int color = 10;
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
        public int GetIndex(int index)
        {
            switch(index)
            {
                case 0:
                    return saku;
                case 1:
                    return obs;
                case 2:
                    return dir;
                case 3:
                    return source;
                case 4:
                    return color;
                case 5:
                    return itemType;
                case 6:
                    return block2;
                case 7:
                    return itemCoudition;
                default:
                    return -1;
            }
        }
        public void SetIndex(int index,int value)
        {
            switch (index)
            {
                case 0:
                    saku = value;
                    break;
                case 1:
                    obs = value;
                    break;
                case 2:
                    dir = value;
                    break;
                case 3:
                    source = value;
                    break;
                case 4:
                    color = value;
                    break;
                case 5:
                    itemType = value;
                    break;
                case 6:
                    block2 = value;
                    break;
                case 7:
                    itemCoudition = value;
                    break;
                default:
                    return ;
            }
        }
        /*
        public void Empty()
        {
            return 
        }
        */
    };
    
    public OutputStr butaString = new OutputStr();
    


    void Start()
    {
        
    }
    
    void Update()
    {
        if(spacePage_sp.gameObject.activeSelf)
        {
            SetViewerMode(1);
        }
        else
            SetViewerMode(0);
    }

    public void SetViewerMode(int mode)
    {
        if(mode == 0)   //nomal mode
        {
            butaBtn.GetComponent<Image>().color = new Color(255,255,255,0);
        }
        else if(mode == 1)  //space mode
        {
            butaBtn.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    public void BtnPush()
    {
        if(block1_sp.gameObject.activeSelf)
        {
            if (block1_sp.SAKU) butaString.saku = block1_sp.blockID;
            else if (block1_sp.OBS) butaString.obs = block1_sp.blockID;
            else if (block1_sp.DIR) butaString.dir = block1_sp.blockID;
            else if (block1_sp.SOURCE) butaString.source = block1_sp.blockID;
            else if (block1_sp.COLOR) butaString.color = block1_sp.blockID;
            else if (block1_sp.ITEM_TYPE) butaString.itemType = block1_sp.blockID;
            else if (block1_sp.BLOCK2) butaString.block2 = block1_sp.blockID;
            else if (block1_sp.ITEM_CONDITION) butaString.itemCoudition = block1_sp.blockID;

            

            if (block1_sp.blockID == 9)
            {
                if(block1.sprite == block1_sp.selectObj.GetComponent<Block1_sp>().solidImgs[0])
                {
                    butaString.obs = 11;
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().solidImgs[1];
                }
                else if(block1.sprite == block1_sp.selectObj.GetComponent<Block1_sp>().solidImgs[1])
                {
                    butaString.obs = 12;
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().solidImgs[2];
                }
                else if(block1.sprite == block1_sp.selectObj.GetComponent<Block1_sp>().solidImgs[2])
                {
                    butaString.obs = 9;
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().solidImgs[0];
                }
                else
                {
                    butaString.obs = 9;
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().solidImgs[0];
                }
                block1.color = new Color(255, 255, 255, 255);
            }
            else if (block1_sp.blockID == 2)
            {
                if (block1.sprite == block1_sp.selectObj.GetComponent<Block1_sp>().blockImgs[0])
                {
                    butaString.saku = 5;
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().blockImgs[1];
                }
                else if (block1.sprite == block1_sp.selectObj.GetComponent<Block1_sp>().blockImgs[1])
                {
                    butaString.saku = 2;
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().blockImgs[0];
                }
                /*
                else if (block1.sprite == block1_sp.selectObj.GetComponent<Block1_sp>().blockImgs[2])
                {
                    butaString.saku = 2;
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().blockImgs[0];
                }
                */
                else
                {
                    butaString.saku = 2;
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().blockImgs[0];
                }
                block1.color = new Color(255, 255, 255, 255);
            }
            else if(block1_sp.blockID == 3)
            {
                if (block1.sprite == block1_sp.selectObj.GetComponent<Block1_sp>().wireImgs[0])
                {
                    butaString.obs = 15;     //輕監牢
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().wireImgs[1];
                }
                else if (block1.sprite == block1_sp.selectObj.GetComponent<Block1_sp>().wireImgs[1])
                {
                    butaString.obs = 3;     //鐵監牢
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().wireImgs[0];
                }
                else
                {
                    butaString.obs = 3;     //鐵監牢
                    block1.sprite = block1_sp.selectObj.GetComponent<Block1_sp>().wireImgs[0];
                }
                block1.color = new Color(255, 255, 255, 255);
            }
            else if (block1_sp.blockID == 0)
            {
                butaString.obs = 0;
                block1.sprite = null;
            }
            else if(block1_sp.blockID != 0)
            {
                block1.sprite = block1_sp.selectObj.GetComponent<Image>().sprite;
                block1.color = new Color(255, 255, 255, 255);
                
            }
            else
            {
                if (block1_sp.SAKU)
                {
                    block1.sprite = block1_sp.selectObj.GetComponent<Image>().sprite;
                    block1.color = new Color(255, 255, 255, 255);
                }
                else
                {
                    block1.sprite = null;
                    block1.color = new Color(255, 255, 255, 0);
                }
                
            }

            

        }
        else if(block2_sp.gameObject.activeSelf)
        {
            if (block2_sp.SAKU) butaString.saku = block2_sp.blockID;
            else if (block2_sp.OBS) butaString.obs = block2_sp.blockID;
            else if (block2_sp.DIR) butaString.dir = block2_sp.blockID;
            else if (block2_sp.SOURCE) butaString.source = block2_sp.blockID;
            else if (block2_sp.COLOR) butaString.color = block2_sp.blockID;
            else if (block2_sp.ITEM_TYPE) butaString.itemType = block2_sp.blockID;
            else if (block2_sp.BLOCK2) butaString.block2 = block2_sp.blockID;
            else if (block2_sp.ITEM_CONDITION) butaString.itemCoudition = block2_sp.blockID;
            //srtingObj.text = title + str.Output();
            if (block2_sp.blockID != 0)
            {
                block2.sprite = block2_sp.selectObj.GetComponent<Image>().sprite;
                block2.color = new Color(255, 255, 255, 255);

            }
            else
            {
                block2.sprite = null;
                block2.color = new Color(255, 255, 255, 0);
            }
            
        }
        else if(item_sp.gameObject.activeSelf)
        {
            if(item_sp.selectPigObj == null)
            {
                butaString.itemType = 0;
                butaString.source = 1;
                butaString.color = 10;
            }
            else if (item_sp.selectPigObj != null)
            {
                butaString.itemType = item_sp.selectPigType;
                butaString.color = item_sp.color;
                if (item_sp.selectBuffObj != null)
                    butaString.itemCoudition = item_sp.selectBuffType;
            }
            else
                if (item_sp.selectBuffObj != null)
                    butaString.source = item_sp.selectBuffType;

            //srtingObj.text = title + str.Output();
            if(item_sp.selectPigObj != null)
            {
                item.sprite = item_sp.selectPigObj.GetComponent<Image>().sprite;
                item.color = new Color(255, 255, 255, 255);
                if(block1.sprite == null)
                    block1.color = new Color(255, 255, 255, 0);
            }
            else
            {
                item.sprite = null;
                item.color = new Color(255, 255, 255, 0);
            }
            
        }
        else if (source_sp.gameObject.activeSelf)
        {
            if (source_sp.selectBuffObj != null)
            {
                butaString.source = source_sp.selectBuffType;
            }
            
        }
        else if(spacePage_sp.gameObject.activeSelf)
        {
            if(spacePage_sp.onSelect != null)
            {
                if(spacePage_sp.onSelect.GetComponent<Space_sp>().ID == 0)
                {
                    //red arrow
                }
                else if(spacePage_sp.onSelect.GetComponent<Space_sp>().ID == 1)
                {
                    //spin
                    switch (spaceDir)
                    {
                        case 0:
                            spaceDir = 3;
                            break;
                        case 1:
                            spaceDir = 2;
                            break;
                        case 2:
                            spaceDir = 0;
                            break;
                        case 3:
                            spaceDir = 1;
                            break;
                    }

                    butaBtn.transform.Rotate(new Vector3(0, 0, 90));
                    butaString.SetIndex(2, spaceDir);       //設定重力
                }
                else if(spacePage_sp.onSelect.GetComponent<Space_sp>().ID == 2)
                {
                    //portal
                    int portalIn = 0;
                    int portalOut = 0;
                    GameObject viewerPort = GameObject.FindGameObjectWithTag("GameScreen");
                    foreach(GameObject i in viewerPort.GetComponent<GameScreen_sp>().butaObjects)
                    {
                        if (i.GetComponent<Buta_sp>().hasPortalIn)
                            portalIn++;
                        else if (i.GetComponent<Buta_sp>().hasPortalOut)
                            portalOut++;
                    }
                    if(portalIn == portalOut)
                    {
                        butaBtn.GetComponent<Image>().sprite = spacePage_sp.onSelect.GetComponent<Space_sp>().portalImgs[0];
                        spacePage_sp.onSelect.GetComponent<Space_sp>().PortalSet(true,this.gameObject);
                        hasPortalIn = true;
                    }
                    else if(portalIn > portalOut)
                    {
                        butaBtn.GetComponent<Image>().sprite = spacePage_sp.onSelect.GetComponent<Space_sp>().portalImgs[1];
                        spacePage_sp.onSelect.GetComponent<Space_sp>().PortalSet(false,this.gameObject);
                        hasPortalOut = true;
                    }
                }
            }
        }
        else
        {
            Debug.Log(this.name + butaString.Output());

        }

    }

    public void ButaInfoSet(int[] info)
    {
        //Debug.Log(info.IntToString());
        for(int i=0;i<info.Length;i++)
        {
            
            if (butaString.GetIndex(i) != info[i])
            {
                butaString.SetIndex(i, info[i]);
                if (i == 0 || i == 1) 
                {
                    block1.sprite = imageSource.GetImage(i, info[i]);
                    block1.color = new Color(255, 255, 255, 255);
                }
                else if (i == 6) 
                {
                    block2.sprite = imageSource.GetImage(i, info[i]);
                    block2.color = new Color(255, 255, 255, 255);
                }
                else if (i == 5)
                {
                    item.sprite = imageSource.GetImage(i, info[i]);
                    item.color = new Color(255, 255, 255, 255);
                }
            }
                
        }
    }
    /*
    public void ButaInfoSet(int[] info)
    {
        //Debug.Log(info.IntToString());
        for(int i=0;i<info.Length;i++)
        {
            
            if (butaString.GetIndex(i) != info[i])
            {
                butaString.SetIndex(i, info[i]);
                if (i == 0 || i == 1) 
                {
                    block1.sprite = imageSource.GetImage(i, info[i]);
                    block1.color = new Color(255, 255, 255, 255);
                }
                else if (i == 6) 
                {
                    block2.sprite = imageSource.GetImage(i, info[i]);
                    block2.color = new Color(255, 255, 255, 255);
                }
                else if (i == 5)
                {
                    item.sprite = imageSource.GetImage(i, info[i]);
                    item.color = new Color(255, 255, 255, 255);
                }
            }
                
        }
    } 
     */

}
