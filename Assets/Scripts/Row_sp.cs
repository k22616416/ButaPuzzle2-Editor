using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Row_sp : MonoBehaviour
{
    public TMP_InputField input;
    public int rowValue
    {
        get
        {
            return int.Parse(input.text);
        }
        set
        {
            input.text = value.ToString();
        }
    }
}
