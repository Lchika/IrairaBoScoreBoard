using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndDirector : MonoBehaviour {

    //public Text bulletNumText;
    public Text playTimeText;
	public SerialHandler serialHandler;

    // Use this for initialization
    void Start () {
		serialHandler = GameObject.Find ("SerialHandler").GetComponent<SerialHandler>();
		//信号を受信したときに、そのメッセージの処理を行う
		serialHandler.OnDataReceived += OnDataReceived;
		serialHandler.SetSceneState (SerialHandler.SceneStateE.sceneStatePlaying);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			//serialHandler.Write ("1");
			SceneManager.LoadScene("ResultScene");
        }
	}

	//受信した信号(message)に対する処理
	void OnDataReceived(string message)
	{
		if (serialHandler.getSceneState() == SerialHandler.SceneStateE.sceneStatePlaying) {
			try {
				if (message == "f") {
					SceneManager.LoadScene ("ResultScene");
				}
			} catch (System.Exception e) {
				Debug.LogWarning (e.Message);
			}
		}
	}
}
