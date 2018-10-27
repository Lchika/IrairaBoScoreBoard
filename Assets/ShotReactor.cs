using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotReactor : MonoBehaviour {

    public SerialHandler serialHandler;
    public Text bulletNumText;
    public Text scoreText;
    int bulletNum = 30;
    public static int score = 0;
	private GameObject hitObject;
	private GameObject hitImageObject;
	private GameObject hitTextObject;

    // Use this for initialization
    void Start()
    {
		score = 0;
		serialHandler = GameObject.Find ("SerialHandler").GetComponent<SerialHandler>();
		//信号を受信したときに、そのメッセージの処理を行う
		serialHandler.OnDataReceived += OnDataReceived;
		hitObject = GameObject.Find ("HitLabel");
		hitImageObject = GameObject.Find ("TargetImage");
		hitTextObject = GameObject.Find ("HitText");
		hitObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
		// 右クリックされたら的命中処理を実行する（デバッグ用）
		if (Input.GetMouseButtonDown (1)) {
			ReactTargetHit ();
			/*
			hitObject.SetActive (true);
			hitTextObject.SetActive(false);
			hitImageObject.GetComponent<TargetImage> ().PerformAnimation();
			*/
		}
    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        try
        {
            if (message == "h")
            {
                bulletNum--;
                Debug.Log("bulletNum = " + bulletNum.ToString());
                bulletNumText.text = bulletNum.ToString();
            }
            if (message == "p")
            {
				ReactTargetHit();
				/*
                score++;
                Debug.Log("score = " + score.ToString());
                scoreText.text = score.ToString();
                */
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

	void ReactTargetHit(){
		score = int.Parse(scoreText.text) + 10;
		Debug.Log("score = " + score.ToString());
		scoreText.text = score.ToString();
		GameObject scoreImageDirector = GameObject.Find ("ScoreImageDirector");
		scoreImageDirector.GetComponent<ScoreImageDirector> ().FillScoreImage ();
		hitObject.SetActive (true);
		hitTextObject.SetActive(false);
		hitImageObject.GetComponent<TargetImage> ().PerformAnimation();
	}
}
