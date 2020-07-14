using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Field : MonoBehaviour
{
    public bool isColorField;
    [SerializeField]
    public List<ItemClass> items = new List<ItemClass>();
    [SerializeField]
    public int fieldIndex
    {
        get
        {
            return int.Parse(this.transform.name);
        }
    }
    [SerializeField]
    //public List<ItemClass[]> colors = new List<ItemClass[]>();
    public List<Field> colors = new List<Field>();

    public Sprite GetImage(int type)
    {
        foreach(ItemClass i in items)
        {
            if(i.enabel && i.type==type)
            {
                return i.imageSource;
            }
        }
        return null;

    }

    public Sprite GetImage(int type,int color)
    {
        foreach(Field i in colors)
        {
            if(i.fieldIndex == type)
            {
                return i.items[color].imageSource;
            }
        }
        return null;
    }
    void Start()
    {
        if(isColorField)
        {
            for(int i=0;i<this.transform.childCount;i++)
            {
                colors.Add(this.transform.GetChild(i).GetComponent<Field>());
            }
            //Debug.Log("OK");
        }
    }
}
