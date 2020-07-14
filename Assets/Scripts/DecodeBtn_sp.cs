using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecodeBtn_sp : MonoBehaviour
{
    public GameObject controlBtn;
    public GameObject codeBtn;
    public TMP_InputField console;
    public TMP_Text displayText;
    public Scrollbar bar;
    public GameObject startDecode;
    public LevelInfo_sp level;
    public GameObject[] butaObj;
    public GameScreen_sp gameScreen;

    /* Pages */
    public Block1_Page_sp block1_sp;
    public Block2_Page_sp block2_sp;
    public Item_Page_sp item_sp;
    public Item_Page_sp source_sp;
    public Space_Page_sp spacePage_sp;



    public bool consoleStatus;
    public FieldManagement fieldManagement;
    



    void Start()
    {
        displayText = this.transform.GetChild(0).GetComponent<TMP_Text>();
    }
    
    void Update()
    {
        
    }
    public IEnumerator Decode()
    {
        string current;
        
        console.text += "\r\n";
        while (true)
        {
            try
            {
                current = console.text.Substring(0, console.text.IndexOf("\r\n"));
            }
            catch(ArgumentOutOfRangeException e)
            {
                
                current = String.Empty;
                
            }

            if (String.IsNullOrEmpty(current))
                break;
                
            
                

            current += ";";
            //Debug.Log(current);
            if(current.IndexOf("MODE") != -1)
            {
                int mode;
                int.TryParse(current[5].ToString(),out mode);
                Debug.Log("MODE " + mode);
                level.SetTarget(mode);
            }
            else if(current.IndexOf("SIZE") != -1)
            {
                int row, col;
                int.TryParse(current.Substring(5,current.IndexOf("/") - 5), out col);
                int.TryParse(current.Substring(7, current.IndexOf(";") - 7), out row);
                Debug.Log("SIZE " + col + "/" + row);
                level.col = col;
                level.row = row;
            }
            else if (current.IndexOf("COLOR LIMIT") != -1)
            {
                int colorLimit;
                int.TryParse(current[12].ToString(), out colorLimit);
                Debug.Log("COLOR LIMIT " + colorLimit);
                level.colorLimit = colorLimit;
            }
            else if(current.IndexOf("LIMIT") != -1)
            {
                int mode, step;
                int.TryParse(current[6].ToString(), out mode);
                int.TryParse(current.Substring(8, current.IndexOf(";") - 8), out step);
                Debug.Log("LIMIT " + mode + "/" + step);
                level.SetLimit(new LevelInfo_sp.Limit_T(mode, step));
            }
            else if(current.IndexOf("STARS") != -1)
            {
                LevelInfo_sp.StarLevel_T s = new LevelInfo_sp.StarLevel_T();
                
                long.TryParse(current.Substring(6, current.IndexOf("/") - 6), out s.star1);
                current = current.Substring(current.IndexOf("/") + 1);
                long.TryParse(current.Substring(0, current.IndexOf("/")), out s.star2);
                current = current.Substring(current.IndexOf("/") + 1);
                long.TryParse(current.Substring(0, current.IndexOf(";")), out s.star3);
                Debug.Log("STARS " + s.star1 + "/" + s.star2 + "/" + s.star3);
                level.SetStars(s);

            }
            else if(current.IndexOf("COLLECT COUNT") != -1)
            {
                Vector2 collectCount;
                float.TryParse(current.Substring(13, current.IndexOf("/")-13), out collectCount.x);
                current = current.Substring(current.IndexOf("/") + 1);
                float.TryParse(current.Substring(0, current.IndexOf(";")), out collectCount.y);
                Debug.Log("COLLECT COUNT " + collectCount.x + "/" + collectCount.y);
                level.SetCollect((int)collectCount.x,(int)collectCount.y);
            }
            else if(current.IndexOf("COLLECT ITEMS") != -1)
            {

            }

            console.text = console.text.Substring(console.text.IndexOf("\n")+1);
            yield return new WaitForSeconds(0.1f);
        }

        controlBtn.GetComponent<ControlButton_sp>().SetLevelSize();
        yield return new WaitForSeconds(1f);
        console.text = console.text.Substring(console.text.IndexOf("\n")+1);

        List<int[]> butaInfo = new List<int[]>();
        int cur = 1;
        while (true)
        {
            
            try
            {
                current = console.text.Substring(0, console.text.IndexOf('\n'));
                console.text = console.text.Substring(console.text.IndexOf('\n') + 1);
                Debug.Log("Line :" + cur);
                //current = console.text.Substring(0, console.text.IndexOf(" "));
            }
            catch (ArgumentOutOfRangeException e)
            {
                current = String.Empty;
            }

            if (String.IsNullOrEmpty(current))
                break;

            //Debug.Log(current.ToString());
            List<String> line = new List<string>();
            string[] infoStr = current.Split(' ');
            foreach(string i in infoStr)
            {
                //Debug.Log(i);
                line.Add(i);
            }
            

            //string[] tmp = current.Split(',');
            
            
            foreach (string i in line)
            {
                List<int> infoArray = new List<int>();
                //Debug.Log(i);
                string[] tmp = i.Split(',');
                foreach(string k in tmp)
                {
                    infoArray.Add(int.Parse(k));
                    
                }
                
                butaInfo.Add(infoArray.ToArray());
                //Debug.Log(i);
                yield return new WaitForSeconds(0.1f);
            }

            if (butaInfo.ToArray().Length == level.col * level.row)
                break;
            //else
                //console.text = console.text.Substring(console.text.IndexOf('\n') + 1);
            
            cur++;
            //yield return new WaitForSeconds(0.1f);
        }
        //yield return new WaitForSeconds(1f);

        FineButaObject();   //get buta obj
        yield return new WaitForSeconds(1f);

        for (int i=0;i<butaObj.Length;i++)
        {
            Debug.Log("buta " + i + " : " + butaInfo[i].ToString());
            fieldManagement.Parsing(butaInfo[i], butaObj[i].GetComponent<Buta_sp>());
            //butaObj[i].GetComponent<Buta_sp>().ButaInfoSet(butaInfo[i]);
            /*
            try
            {
                butaObj[i].GetComponent<Buta_sp>().ButaInfoSet(butaInfo[i]);
            }
            catch(Exception e)
            {
                Debug.Log(e.GetType());
                Debug.Log(e.Message);
            }
            */
            //Debug.Log("Buta " + i + " : " + butaInfo[i].ToString());

        }
        

        /*Set buta info*/


        Debug.Log("All done.");
        yield return new WaitForSeconds(0.1f);
        controlBtn.GetComponent<ControlButton_sp>().butaInit = true;
        //BtnPush();

    }

    public void BtnPush()
    {
        
        //if (codeBtn.GetComponent<CodeBtn_sp>().consoleStatus)
        //    return;
        consoleStatus = !consoleStatus;
        if(consoleStatus)
        {
            
            console.gameObject.SetActive(true);
            bar.gameObject.SetActive(true);
            startDecode.gameObject.SetActive(true);
            displayText.text = "Close";
            codeBtn.SetActive(false);
        }
        else
        {
            console.gameObject.SetActive(false);
            bar.gameObject.SetActive(false);
            startDecode.gameObject.SetActive(false);
            displayText.text = "Decode";
            codeBtn.SetActive(true);
        }
    }

    public void StartDecode()
    {
        StartCoroutine("Decode");
    }

    public void FineButaObject()
    {
        if (butaObj.Length != gameScreen.butaObjects.Length)
        {
            butaObj = new GameObject[gameScreen.butaObjects.Length];
            int index = 0;
            foreach (GameObject g in gameScreen.butaObjects)
            {
                butaObj[index] = g;
                index++;
            }
        }
    }
    /*
    public IEnumerator ImageInclude()
    {
        block1_sp.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        for (int i=0;i< block1_sp.blocks.Length;i++)
        {

        }
        block1_sp.gameObject.SetActive(false);
        yield return 0;
    }
    */
}
/*
MODE 1
SIZE 5/5
LIMIT 0/23
COLOR LIMIT 6
COLLECT COUNT 40/40
STARS 1000/1300/1600

1,7,0,1,10,0,0,0 1,3,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0
1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0
1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0
1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0
1,7,0,1,10,0,0,0 1,3,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0 1,0,0,1,10,0,0,0
 
 */

/*
 紀錄Item內容的格式

1,0,0,1,10,0,0,0是最常見的格式

其中第一個1表示：是否有該square或柵欄，0表示那區域是空白的，１則是有物件但沒有柵欄，2則是有一次性柵欄，5則是兩次性的白色柵欄

接著第二個0表示：障礙物種類0表示沒有障礙物，其中第一個跟第二個的索引值都可以參考Square類別裡面的SquareTypes

第一個1跟第二個0共用以下的enum列舉，其資料如下：

public enum SquareTypes
{
  NONE = 0,
  EMPTY,
  BLOCK,
  WIREBLOCK,
  SOLIDBLOCK,
  DOUBLEBLOCK,
  UNDESTROYABLE,
  THRIVING,
  DOUBLESOLIDBLOCK,
  EXCREMENTBLOCK,
  TRIPLESOLIDBLOCK,
  DOUBLEEXCREMENTBLOCK,
  TRIPLEEXCREMENTBLOCK,
  GRAVITYBLOCK,
  TIMEBLOCK,
  LITEWIREBLOCK,
  TRIPLEBLOCK,
  OILBLOCK,
}

再來第三個0表示：重力方向 0下 1上 2左 3右（可參考Square的GravityDirection）

public enum GravityDirection
{
  DOWN,
  UP,
  LEFT,
  RIGHT,
}

第四個1表示：此欄位為Source，但目前還沒設計，之前是打算讓此位置生成特殊物件，例如一個會不斷產生金豬的方塊區域

public enum CreateSource
{
  NONE = 0,
  EMPTY,
  ADD_TIMER,
  OLDING,
  OLD,
  LARGEBLACK,
}

第五個10表示：表示拼圖顏色，10是隨機，0~5是指定顏色

今天已修正指定顏色之後可能會跟旁邊顏色相同導致開場就直接三消的問題

第六個0表示：ItemType，如金豬 忍者 山豬等

public enum ItemsTypes
{
  NONE = 0,
  VERTICAL_STRIPPED,
  HORIZONTAL_STRIPPED,
  PACKAGE,
  BOMB,
  COLOR_BOMB,
  INGREDIENT,
  BOMB_VERTICAL_STRIPPED,
  BOMB_HORIZONTAL_STRIPPED,
  BOMB_PACKAGE,
  OLD,
  MARMALADE,
}

第七個0表示block2，該欄位儲存背景類型的障礙物 例如草地

public enum Grass
{
  NONE,
  GRASS,
  FALLGRASS,
}

第八個0表示ItemCondition，該欄位表示此拼圖是否已經老化或帶有時間炸彈之類的狀態類型

public enum ItemCondition
{
  NONE,
  OLDING,
  HASOLD,
  ADDTIME,
} 
 */
