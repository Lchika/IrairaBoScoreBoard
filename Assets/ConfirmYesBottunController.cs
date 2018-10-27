using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmYesBottunController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// ボタンをクリックした時の処理
	public void OnClick() {
		Debug.Log("Yes Button click");
		SceneManager.LoadScene("RegistationScene");
	}
}
