using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreResultShowManager : MonoBehaviour {

	public Text scoreText;
	public Text rankText;
	//private static int testCount = 100;
	//private string testName = "test";

	// Use this for initialization
	void Start () {
		scoreText.text = ShotReactor.score.ToString ();
		int rank = GameObject.Find ("RankingListManager").GetComponent<RankingListManager> ().getRankFromRankingList (ShotReactor.score);
		//int rank = GameObject.Find ("RankingListManager").GetComponent<RankingListManager>().registerRankingList (ShotReactor.score, testName);
		Debug.Log("rank = " + rank.ToString ());
		rankText.text = rank.ToString ();
		//testCount--;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
