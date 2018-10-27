using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShowManager : MonoBehaviour {

	private const int NumberOfScore = 10;
	GameObject scorePrefab;
	public Text[] userText = new Text[NumberOfScore];
	public Text[] scoreText = new Text[NumberOfScore];
	public GameObject[] rankObjects = new GameObject[NumberOfScore];
	private int i = 0;
	private RankingListManager rankingListManager;

	// Use this for initialization
	void Start () {
		rankingListManager = GameObject.Find ("RankingListManager").GetComponent<RankingListManager> ();

		for (i = 0; i < NumberOfScore; i++) {
			rankObjects [i] = GameObject.Find ("Rank" + (i + 1).ToString() + "Label");
			userText [i] = GameObject.Find ("Rank" + (i + 1).ToString() + "User").GetComponent<Text> ();
			scoreText [i] = GameObject.Find ("Rank" + (i + 1).ToString() + "Score").GetComponent<Text> ();
			//rankText [i] = GameObject.Find ("Rank" + (i + 1).ToString()).GetComponent<Text> ();
			//rankObjects [i].SetActive (false);
			//rankText [i].text = "Rank" + (i + 1).ToString() + " : " + GameObject.Find ("RankingListManager").GetComponent<RankingListManager>().getScoreByRank(i + 1).ToString();
			userText [i].text = rankingListManager.getNameByRank(i + 1);
			scoreText [i].text = rankingListManager.getScoreByRank (i + 1).ToString ();
		}
		/*
		for (i = 3; i < NumberOfScore; i++) {
			rankObjects [i] = GameObject.Find ("Rank" + (i + 1).ToString() + "Label");
			rankText [i] = GameObject.Find ("Rank" + (i + 1).ToString()).GetComponent<Text> ();
			//rankText [i] = GameObject.Find ("Rank" + (i + 1).ToString()).GetComponent<Text> ();
			//rankObjects [i].SetActive (false);
			//rankText [i].text = "Rank" + (i + 1).ToString() + " : " + GameObject.Find ("RankingListManager").GetComponent<RankingListManager>().getScoreByRank(i + 1).ToString();
			rankText [i].text = (i + 1).ToString() + "位 : " + rankingListManager.getNameByRank(i + 1) + " : " + rankingListManager.getScoreByRank(i + 1).ToString();
		}
		*/

		//StartCoroutine("showScoresAscendingOrder");
	}

	// Update is called once per frame
	void Update () {

	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator showScoresAscendingOrder(){
		for (i = 0; i < NumberOfScore; i++) {
			rankObjects [i].SetActive (true);
			yield return new WaitForSeconds(1);  //1秒待つ
		}
	}
}
