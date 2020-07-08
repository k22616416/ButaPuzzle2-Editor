using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Star_sp : MonoBehaviour
{
    public TMP_InputField star1;
    public TMP_InputField star2;
    public TMP_InputField star3;
    public long starsValue1
    {
        get
        {
            return long.Parse(star1.text);
        }
        set
        {
            star1.text = value.ToString();
        }
    }
    public long starsValue2
    {
        get
        {
            return long.Parse(star2.text);
        }
        set
        {
            star2.text = value.ToString();
        }
    }
    public long starsValue3
    {
        get
        {
            return long.Parse(star3.text);
        }
        set
        {
            star3.text = value.ToString();
        }
    }


}
