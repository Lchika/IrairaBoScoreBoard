using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreResultShowManager : MonoBehaviour {

	public Text timeText;
	public Text missText;
	public Text rankText;
	//private static int testCount = 100;
	//private string testName = "test";

	// Use this for initialization
	void Start () {
		timeText.text = ((int)(Timer.countTime / 60)).ToString ("D2") + ":" + ((int)Timer.countTime % 60).ToString ("D2");
		missText.text = ShotReactor.miss.ToString ();
		//int rank = GameObject.Find ("RankingListManager").GetComponent<RankingListManager> ().getRankFromRankingList (ShotReactor.miss);
		int rank = GameObject.Find ("RankingListManager").GetComponent<RankingListManager>().registerRankingList (ShotReactor.miss, Timer.countTime);
		Debug.Log("rank = " + rank.ToString ());
		rankText.text = rank.ToString ();
		//testCount--;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
