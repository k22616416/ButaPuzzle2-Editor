using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class FieldManagement : MonoBehaviour
{
    
    public List<Field> fields = new List<Field>();
    void Start()
    {
        for(int i=0;i<this.transform.childCount;i++)
        {
            fields.Add(this.transform.GetChild(i).GetComponent<Field>());
        }
    }

    void Update()
    {
        
    }

    public Sprite GetImage(int index,int type)
    {
        //if(index == 5)  return fields[index - 1].GetImage(index,type);
        return fields[index].GetImage(type);
    }
    

    public void Parsing(int[] info,Buta_sp obj)
    {
        for (int i = 0; i < info.Length; i++)
        {
            Debug.Log("info:" + info[i]);
            obj.butaString.SetIndex(i, info[i]);
            if (i == 0 || i == 1) //block1
            {
                obj.block1.sprite = GetImage(i, info[i]);
                obj.block1.color = new Color(255, 255, 255, 255);
            }
            else if (i == 6) //block2
            {
                obj.block2.sprite = GetImage(i, info[i]);
                obj.block2.color = new Color(255, 255, 255, 255);
            }
            else if (i == 4 && info[i] != 10) //color
            {
                obj.item.sprite = fields[i].GetImage(info[5], info[i]);
                obj.item.color = new Color(255, 255, 255, 255);
                if (obj.block1.sprite == null)
                    obj.block1.color = new Color(255, 255, 255, 0);
                if (obj.block2.sprite == null)
                    obj.block2.color = new Color(255,255,255,0);
            }
            else if(i == 2) //space
            {
                switch(info[i])
                {
                    case 0: //up
                        obj.butaBtn.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 1: //down
                        obj.butaBtn.transform.rotation = Quaternion.Euler(0, 0, 180);
                        break;
                    case 2: //left
                        obj.butaBtn.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    case 3: //right
                        obj.butaBtn.transform.rotation = Quaternion.Euler(0, 0, 270);
                        break;
                }
                //obj.butaBtn.transform.Rotate(new Vector3(0, 0, 90));
                obj.butaString.SetIndex(2, info[i]);
            }
        }

        return ;
    }
}
