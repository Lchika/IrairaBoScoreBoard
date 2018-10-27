using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSleepDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 	左クリックされたらゲーム中画面に遷移する（デバッグ用）
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene("RankingScene");
		}
	}
}
