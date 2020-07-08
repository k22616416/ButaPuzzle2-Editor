using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Space_sp : MonoBehaviour
{
    public Sprite[] imgs;
    public Sprite[] portalImgs;
    public GameObject mask;
    public bool hasArrow;
    public int ID;
    Space_Page_sp spacePage;
    int imageIndex;
    public bool onSelect;
    public bool portalOpen;

    GameObject portalInObj;
    void Start()
    {
        spacePage = GameObject.FindGameObjectWithTag("Space_Page").GetComponent<Space_Page_sp>();
    }
    
    void Update()
    {
        
    }
    public void BtnPush()
    {
        onSelect = !onSelect;
        if(onSelect)
        {
            mask.SetActive(true);
            spacePage.GetComponent<Space_Page_sp>().SelectObj(this.gameObject);
        }
        else
        {
            mask.SetActive(false);
            imageIndex = 0;
            spacePage.GetComponent<Space_Page_sp>().SelectObj(null);
            if (hasArrow)
            {
                imageIndex = 0;
                this.gameObject.GetComponent<Image>().sprite = imgs[imageIndex];
            }
        }
    }
    public void ArrowPush()
    {
        if(onSelect)
            imageIndex++;
        if (imageIndex >= imgs.Length)
        {
            mask.SetActive(false);
            imageIndex = 0;
            onSelect = false;
            spacePage.GetComponent<Space_Page_sp>().SelectObj(null);
        }
        else
        {
            mask.SetActive(true);
            onSelect = true;
            spacePage.GetComponent<Space_Page_sp>().SelectObj(this.gameObject);
        }
            
        this.gameObject.GetComponent<Image>().sprite = imgs[imageIndex];
    }

    public void PortalSet(bool open,GameObject portal)
    {
        
        portalOpen = open;
        if(portalOpen)
        {
            this.gameObject.GetComponent<Image>().sprite = portalImgs[1];
            portalInObj = portal;
            
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = portalImgs[0];
            portalInObj.GetComponent<Buta_sp>().portalTo = portal.GetComponent<Buta_sp>().location;


        }
    }
}
