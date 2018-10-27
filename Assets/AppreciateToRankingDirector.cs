using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppreciateToRankingDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("moveToRankingScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator moveToRankingScene(){
		yield return new WaitForSeconds(4);  //4秒待つ
		SceneManager.LoadScene("RankingScene");
	}
}
