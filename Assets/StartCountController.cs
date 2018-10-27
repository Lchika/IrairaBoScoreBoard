using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartCountController : MonoBehaviour {

	private Text countText;
	private const int maxCount = 5;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		countText = GetComponent<Text>();
		sound = GetComponent<AudioSource>();
		StartCoroutine("countDownStartTime", maxCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator countDownStartTime(int maxCount){
		for(int i = maxCount; i > 0; i--){
			countText.text = i.ToString ();
			sound.PlayOneShot(sound.clip);
			yield return new WaitForSeconds(1);  //1秒待つ
		}
		SceneManager.LoadScene("PlayingGameScene");
	}
}
