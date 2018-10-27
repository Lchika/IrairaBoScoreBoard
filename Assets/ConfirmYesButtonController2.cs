using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfirmYesButtonController2 : MonoBehaviour {

	private InputField inputField;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// ボタンをクリックした時の処理
	public void OnClick() {
		Debug.Log("Yes Button click");
		GameObject.Find ("RankingListManager").GetComponent<RankingListManager>().registerRankingList (ShotReactor.score, GameObject.Find ("Name").GetComponent<Text> ().text);
		SceneManager.LoadScene("AppreciationScene");
	}
}
