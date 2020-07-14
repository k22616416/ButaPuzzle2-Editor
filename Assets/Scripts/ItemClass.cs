using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

[Serializable]
public class ItemClass
{
    public string name;
    public Sprite imageSource;
    public int type = -10;
    public bool enabel;
    [Header("備註")]
    public string mark;
}
