using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSleepDirector : MonoBehaviour {

	public SerialHandler serialHandler;

	// Use this for initialization
	void Start () {
		serialHandler = GameObject.Find ("SerialHandler").GetComponent<SerialHandler>();
		StartCoroutine("moveScene");
		serialHandler.SetSceneState (SerialHandler.SceneStateE.sceneStateResult);
	}
	
	// Update is called once per frame
	void Update () {
		// 	右クリックされたらゲーム中画面に遷移する（デバッグ用）
		if (Input.GetMouseButtonDown (1)) {
            SceneManager.LoadScene("AppreciationScene");
            //SceneManager.LoadScene("RankingScene");
        }
	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator moveScene(){
		yield return new WaitForSeconds(8);
        SceneManager.LoadScene("AppreciationScene");
        //SceneManager.LoadScene("RankingScene");
    }
}
