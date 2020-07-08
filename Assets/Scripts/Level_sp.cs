using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level_sp : MonoBehaviour
{
    public Button rightBtn;
    public Button leftBtn;
    public TMP_Text levelText;
    public int level
    {
        get
        {
            return int.Parse(levelText.text);
        }

        set
        {
            levelText.text = value.ToString();
        }
    }
    
    public void BtnPush(int b)
    {
        if (b == 0)
            level--;
        else
            level++;

    }
}
