using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSleepDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("moveScene");
	}
	
	// Update is called once per frame
	void Update () {
		// 	右クリックされたらゲーム中画面に遷移する（デバッグ用）
		if (Input.GetMouseButtonDown (1)) {
			SceneManager.LoadScene("AppreciationScene");
		}
	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator moveScene(){
		yield return new WaitForSeconds(10);
		SceneManager.LoadScene("AppreciationScene");
	}
}
