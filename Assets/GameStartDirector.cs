using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartDirector : MonoBehaviour {

    public SerialHandler serialHandler;

    // Use this for initialization
    void Start () {
		//if (serialHandler.is_added_event[0] == false) {
			//信号を受信したときに、そのメッセージの処理を行う
			serialHandler.OnDataReceived += OnDataReceived;
			//serialHandler.is_added_event[0] = true;
		//}
		serialHandler.SetSceneState (SerialHandler.SceneStateE.sceneStateRanking);
    }

    // Update is called once per frame
    void Update () {
		// 	左クリックされたらゲーム中画面に遷移する（デバッグ用）
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene("WaitingStartScene");
		}
	}

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
		if (serialHandler.getSceneState() == SerialHandler.SceneStateE.sceneStateRanking) {
			try {
				if (message == "s") {
					SceneManager.LoadScene ("WaitingStartScene");
				}
			} catch (System.Exception e) {
				Debug.LogWarning (e.Message);
			}
		}
    }
}
