using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassReactor : MonoBehaviour
{
    private int currentModuleNum;
    private SerialHandler serialHandler;
    private GameObject passObject;
    private Text passText;

    // Start is called before the first frame update
    void Start()
    {
        currentModuleNum = 1;
        serialHandler = GameObject.Find("SerialHandler").GetComponent<SerialHandler>();
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
        passObject = GameObject.Find("PassLabel");
        //passImageObject = GameObject.Find("PassImage");
        //passTextObject = GameObject.Find("PassText");
        passText = GameObject.Find("PassText").GetComponent<Text>();
        passObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // tキー押されたらモジュール通過処理を実行する（デバッグ用）
        if (Input.GetKeyDown("t"))
        {
            ReactModulePass();
        }

    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        try
        {
            if (message == "t")
            {
                ReactModulePass();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

    void ReactModulePass()
    {
        passText.text = "第" + currentModuleNum.ToString() + "コース\nクリア！";
        StartCoroutine("showObject1sec");
    }

    //「コルーチン」で呼び出すメソッド
    private IEnumerator showObject1sec()
    {
        passObject.SetActive(true);
        yield return new WaitForSeconds(1);  //1秒待つ
        passObject.SetActive(false);
        currentModuleNum++;
    }
}