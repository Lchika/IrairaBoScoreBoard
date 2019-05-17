using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReadyDirector : MonoBehaviour
{
    public SerialHandler serialHandler;

    // Start is called before the first frame update
    void Start()
    {
        serialHandler = GameObject.Find("SerialHandler").GetComponent<SerialHandler>();
        serialHandler.OnDataReceived += OnDataReceived;
        serialHandler.SetSceneState(SerialHandler.SceneStateE.sceneStateWaitingStart);
    }

    // Update is called once per frame
    void Update()
    {
        //  左クリックされたらゲーム中画面に遷移する（デバッグ用）
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("PlayingGameScene");
        }

    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        if (serialHandler.getSceneState() == SerialHandler.SceneStateE.sceneStateWaitingStart)
        {
            try
            {
                if (message == "s")
                {
                    SceneManager.LoadScene("PlayingGameScene");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }
}
