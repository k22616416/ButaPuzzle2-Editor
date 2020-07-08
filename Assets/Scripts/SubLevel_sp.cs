using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubLevel_sp : MonoBehaviour
{
    public Button addBtn;
    public Button subBtn;
    public Button rightBtn;
    public Button leftBtn;
    public TMP_InputField levelText;
    public int subLevelQuantity = 1;
    public int level = 1;

    public void BtnPush(int b)
    {
        if (b == 0 && subLevelQuantity > 0) //+
        {
            subLevelQuantity--;
            
        }
        else if (b == 1) //-
        {
            subLevelQuantity++;
            
        }
        else if (b == 2 && level > 1) //<<
        {
            level--;
            levelText.text = level.ToString();
        }
        else if (b == 3 && level < subLevelQuantity) //>>
        {
            level++;
            levelText.text = level.ToString();
        }
    }

    public void OnValueChanged(string str)
    {
        if(int.Parse(str) > subLevelQuantity)
        {
            levelText.text = subLevelQuantity.ToString();
        }
        else if(int.Parse(str) <= 0)
        {
            levelText.text = "1";
        }
    }
}
