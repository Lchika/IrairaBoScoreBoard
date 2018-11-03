using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppreciateToRankingDirector : MonoBehaviour {

	public GameObject audioController;
	public SerialHandler serialHandler;

	// Use this for initialization
	void Start () {
		serialHandler = GameObject.Find ("SerialHandler").GetComponent<SerialHandler>();
		StartCoroutine ("moveToRankingScene");
		audioController = GameObject.Find ("AudioController");
		serialHandler.SetSceneState (SerialHandler.SceneStateE.sceneStateAppreciate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator moveToRankingScene(){
		yield return new WaitForSeconds(4);  //4秒待つ
		Destroy(audioController);
		SceneManager.LoadScene("RankingScene");
	}
}
