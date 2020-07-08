using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorLimit_sp : MonoBehaviour
{
    public Button right;
    public Button left;
    public TMP_Text colorLimitText;
    [Header("最大顏色數量")]
    public int MaximumColorSize = 6;

    [Header("最小顏色數量")]
    public int MinimumColorSize = 4;
    public int colorSize = 4;
    public void BtnPush(int btn)
    {
        if (btn == 0)    //<
            colorSize--;
        else if (btn == 1)
            colorSize++;

        if (colorSize > MaximumColorSize)
            colorSize--;
        else if (colorSize < MinimumColorSize)
            colorSize++;

        colorLimitText.text = colorSize.ToString();
    }
    
}
