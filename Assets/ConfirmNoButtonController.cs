using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmNoButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// ボタンをクリックした時の処理
	public void OnClick() {
		Debug.Log("No Button click");
		SceneManager.LoadScene("AppreciationScene");
	}
}
