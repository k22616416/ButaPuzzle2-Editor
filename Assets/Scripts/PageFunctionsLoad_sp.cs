using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PageFunctionsLoad_sp : MonoBehaviour
{
    public FunctionClassList functionObjs;
    public List<FunctionClass> sakuObjs = new List<FunctionClass>();
    public List<FunctionClass> obsObjs = new List<FunctionClass>();
    public List<FunctionClass> dirObjs = new List<FunctionClass>();
    public List<FunctionClass> sourceObjs = new List<FunctionClass>();
    public List<FunctionClass> colorObjs = new List<FunctionClass>();
    public List<FunctionClass> itemTypeObjs = new List<FunctionClass>();
    public List<FunctionClass> block2Objs = new List<FunctionClass>();
    public List<FunctionClass> itemConditionObjs = new List<FunctionClass>();

    [SerializeField]
    public List<List<FunctionClass>> imageMembers = new List<List<FunctionClass>>();

    //public GameObject functionTemplate;
    string jsonText;
    void Start()
    {
        StartCoroutine("SourceLoad");
    }
    
    void Update()
    {
        
    }

    public Sprite GetImage(int member,int targetID)
    {
        //Debug.Log("Member:" + member );
        for(int i=0;i<imageMembers[member].ToArray().Length;i++)
        {
            for(int k=0;k< imageMembers[member][i].size;k++)
            {
                if (imageMembers[member][i].id[k] == targetID)
                {
                    //Debug.Log(" i:" + i + " k:" + k);
                    return imageMembers[member][i].image[k];
                }
            }
        }
        return null;
    }

    IEnumerator SourceLoad()
    {
        bool error = false;
        /* get json*/
        try
        {
            jsonText = File.ReadAllText(Application.dataPath + @"\StreamingAssets\PageFunctions\Objects3.json");
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            error = true;
        }
        if (error) yield break;
        //Debug.Log(jsonText);
        
        /* set obj */
        functionObjs = JsonUtility.FromJson<FunctionClassList>(jsonText);
        int objsLength = functionObjs.objs.ToArray().Length;
        for (int i = 0; i < objsLength; i++) 
        {
            int imageSize = functionObjs.getObjects(i).imageSource.Length;
            functionObjs.getObjects(i).image = new Sprite[imageSize];
            for (int k=0;k< imageSize;k++)
            {
                string p = functionObjs.getObjects(i).imageSource[k].ToString();
                if (p == null) continue;
                WWW www = new WWW(Application.dataPath + @"\StreamingAssets\PageFunctions\" + p);
                
                if (www != null && string.IsNullOrEmpty(www.error))
                {
                    Texture2D texture = www.texture;
                    functionObjs.getObjects(i).image[k] = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                }
            }
            switch(functionObjs.getObjects(i).type)
            {
                case "saku":
                    sakuObjs.Add(functionObjs.getObjects(i));
                    break;
                case "obs":
                    obsObjs.Add(functionObjs.getObjects(i));
                    break;
                case "dir":
                    dirObjs.Add(functionObjs.getObjects(i));
                    break;
                case "source":
                    sourceObjs.Add(functionObjs.getObjects(i));
                    break;
                case "color":
                    colorObjs.Add(functionObjs.getObjects(i));
                    break;
                case "itemType":
                    itemTypeObjs.Add(functionObjs.getObjects(i));
                    break;
                case "block2":
                    block2Objs.Add(functionObjs.getObjects(i));
                    break;
                case "itemCondition":
                    itemConditionObjs.Add(functionObjs.getObjects(i));
                    break;
                default:
                    break;

            }
            
        }
        imageMembers.Add(sakuObjs);
        imageMembers.Add(obsObjs);
        imageMembers.Add(dirObjs);
        imageMembers.Add(sourceObjs);
        imageMembers.Add(colorObjs);
        imageMembers.Add(itemTypeObjs);
        imageMembers.Add(block2Objs);
        imageMembers.Add(itemConditionObjs);
        yield return null;


        /* creat object */
    }
}
[Serializable]
public class FunctionClass
{
    public string name;
    public string type;
    public int size;
    public int[] id ;
    public string[] imageSource;
    public Sprite[] image;
}
[Serializable]
public class FunctionClassList
{
    public List<FunctionClass> objs = new List<FunctionClass>();
    
    public FunctionClass getObjects(int index)
    {
        return objs[index];
    }
    
}

