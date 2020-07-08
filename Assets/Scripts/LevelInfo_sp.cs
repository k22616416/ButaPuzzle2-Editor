using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class LevelInfo_sp : MonoBehaviour
{
    /*****************/
    public enum LimitTypes
    {
        Moves,
        Times,

        Length

    };
    public enum TargetTypes
    {
        ReachTheScore = 0,
        CollectTheItems,
        FallDownThePig,
        DestroyTheSaku,
        CleanTheUnchi,
        FillOutTheGrass,

        Length
    };
    public struct Limit_T
    {
        public Limit_T(int type,int step)
        {
            this.type = type;
            this.step = step;
        }
        public int type;
        public int step;

    };

    public struct StarLevel_T
    {
        public long star1;
        public long star2;
        public long star3;
    };

    public struct Target_T
    {
        public int type;
        public int[] collect;
        
        
    };
    /**************************/

    public GameObject levelObj;
    public GameObject subLevelObj;
    public GameObject limitObj;
    public GameObject colorLimitObj;
    public GameObject starsObj;
    public GameObject targetObj;
    public GameObject rowObj;
    public GameObject colObj;

    public int level
    {
        get
        {
            return levelObj.GetComponent<Level_sp>().level;
        }
        set
        {
            levelObj.GetComponent<Level_sp>().level = value;
        }
    }
    public int subLevel
    {
        get
        {
            return subLevelObj.GetComponent<SubLevel_sp>().level;
        }
        set
        {
            subLevelObj.GetComponent<SubLevel_sp>().level = value;
        }
    }
    public Limit_T limit;
    public int colorLimit
    {
        get
        {
            return colorLimitObj.GetComponent<ColorLimit_sp>().colorSize;
        }
        set
        {
            colorLimitObj.GetComponent<ColorLimit_sp>().colorSize = value;
            colorLimitObj.GetComponent<ColorLimit_sp>().colorLimitText.text = value.ToString();
        }
    }
    public StarLevel_T stars;
    public Target_T target;
    
    public int row
    {
        get
        {
            return rowObj.GetComponent<Row_sp>().rowValue;
        }
        set
        {
            rowObj.GetComponent<Row_sp>().rowValue = value;
        }
    }
    public int col
    {
        get
        {
            return colObj.GetComponent<Col_sp>().colValue;
        }
        set
        {
            colObj.GetComponent<Col_sp>().colValue = value ;
        }
    }


    void Start()
    {
        target.collect = new int[2];
    }
    

    void Update()
    {
        limit.type = limitObj.GetComponent<Limit_sp>().type;
        limit.step = limitObj.GetComponent<Limit_sp>().step;

        try
        {
            stars.star1 = starsObj.GetComponent<Star_sp>().starsValue1;
            stars.star2 = starsObj.GetComponent<Star_sp>().starsValue2;
            stars.star3 = starsObj.GetComponent<Star_sp>().starsValue3;
        }
        catch
        {

        }

        target.type = targetObj.GetComponent<Target_sp>().mode;
        if (target.type == (int)LevelInfo_sp.TargetTypes.CollectTheItems || target.type == (int)LevelInfo_sp.TargetTypes.FallDownThePig)
        {
            try
            {
                target.collect = new int[2];
                target.collect = targetObj.GetComponent<Target_sp>().GetCollects();
            }
            catch { }
            //target.collect[0] = int.Parse(targetObj.GetComponent<Target_sp>().collect[0].ToString());
            //target.collect[1] = int.Parse(targetObj.GetComponent<Target_sp>().collect[1].ToString());
        }   
    }
    
    public void SetLimit(Limit_T t)
    {
        limitObj.GetComponent<Limit_sp>().type = t.type;
        limitObj.GetComponent<Limit_sp>().step = t.step;
        limitObj.GetComponent<Limit_sp>().stepText.text = t.step.ToString();
    }

    public void SetTarget(int type)
    {
        targetObj.GetComponent<Target_sp>().mode = type;
        targetObj.GetComponent<Target_sp>().mode =  type;
        targetObj.GetComponent<Target_sp>().targetSwitch.transform.GetChild(0).GetComponent<Text>().text = Enum.GetName(typeof(LevelInfo_sp.TargetTypes), type);
    }
    public void SetCollect(int collect1,int collect2)
    {
        targetObj.GetComponent<Target_sp>().collect[0].text = collect1.ToString();
        targetObj.GetComponent<Target_sp>().collect[1].text = collect2.ToString();
        if (collect1 != 0)
        {
            targetObj.GetComponent<Target_sp>().collect[0].gameObject.SetActive(true);
            targetObj.GetComponent<Target_sp>().collect[1].gameObject.SetActive(true);
        }
            
    }
    public void SetStars(StarLevel_T s)
    {
        starsObj.GetComponent<Star_sp>().starsValue1 = s.star1;
        starsObj.GetComponent<Star_sp>().starsValue2 = s.star2;
        starsObj.GetComponent<Star_sp>().starsValue3 = s.star3;
    }
}
