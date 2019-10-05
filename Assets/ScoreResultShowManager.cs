using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreResultShowManager : MonoBehaviour {

	public Text ueTimeText;
	public Text ueMissText;
	public Text ueRankText;
    public Text ueScoreText;
	public Text nakaTimeText;
	public Text nakaMissText;
	public Text nakaRankText;
    public Text nakaScoreText;
    public Text shitaTimeText;
	public Text shitaMissText;
	public Text shitaRankText;
    public Text shitaScoreText;
    public Text nakaAllNum;

	RankingListManager rankingListManager;
	//private static int testCount = 100;
	//private string testName = "test";

	// Use this for initialization
	void Start () {
		rankingListManager = GameObject.Find ("RankingListManager").GetComponent<RankingListManager>();
		//int rank = GameObject.Find ("RankingListManager").GetComponent<RankingListManager> ().getRankFromRankingList (ShotReactor.miss);
		int rank = rankingListManager.registerRankingList (ShotReactor.miss, Timer.countTime);
		Debug.Log("rank = " + rank.ToString ());
		nakaRankText.text = rank.ToString ();
		nakaTimeText.text = ((int)(Timer.countTime / 60)).ToString ("D2") + ":" + ((int)Timer.countTime % 60).ToString ("D2");
		nakaMissText.text = ShotReactor.miss.ToString ();
        nakaScoreText.text = ((int)rankingListManager.getScoreByRank(rank)).ToString();
        //Debug.Log("playerNum = " + rankingListManager.getPlayerNum ().ToString ());
        nakaAllNum.text = "/" + rankingListManager.getPlayerNum ().ToString () + "人中";

		// 1位だった場合は上のラベルを非表示にし、テキストも更新しない
		if (rank == 1) {
			GameObject.Find ("UeLabel").SetActive (false);
		} else {
			ueRankText.text = (rank - 1).ToString ();
			float ueTime = rankingListManager.getTimeByRank (rank - 1);
			ueTimeText.text = ((int)(ueTime / 60)).ToString ("D2") + ":" + ((int)ueTime % 60).ToString ("D2");
            ueMissText.text = rankingListManager.getMissByRank(rank - 1).ToString();
            ueScoreText.text = ((int)rankingListManager.getScoreByRank(rank - 1)).ToString();
		}

		// 最下位または最大保持人数だった場合は下のラベルを非表示にし、テキストも更新しない
		if (rank == rankingListManager.getPlayerNum() || rank == rankingListManager.getNumberOfScoreInfo()) {
			GameObject.Find ("ShitaLabel").SetActive (false);
		} else {
			shitaRankText.text = (rank + 1).ToString ();
			float shitaTime = rankingListManager.getTimeByRank (rank + 1);
			shitaTimeText.text = ((int)(shitaTime / 60)).ToString ("D2") + ":" + ((int)shitaTime % 60).ToString ("D2");
			shitaMissText.text = rankingListManager.getMissByRank (rank + 1).ToString ();
            shitaScoreText.text = ((int)rankingListManager.getScoreByRank(rank + 1)).ToString();
        }
			
		//testCount--;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
