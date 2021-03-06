﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RankingListManager : MonoBehaviour {

	private struct scoreInfo
	{
		public float time;	// クリア時間[s]
		public int miss;
	}

    [System.Serializable]
    public class scoreJson
    {
        public scoreData score;
    }

    [System.Serializable]
    public class scoreData
    {
        public string name;
        public string time;
        public string miss;
        public string score;
        public string difficulty;
    }

    public static RankingListManager singleton;
	private const int NumberOfScoreInfo = 1024;
    private const int PenaByMiss = 10;
	private static scoreInfo[] scoreInfos = new scoreInfo[NumberOfScoreInfo];
    private static int playerNum = 0;

	void Awake () {
		//　スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
		if (singleton == null) {
			DontDestroyOnLoad (gameObject);
			singleton = this;
			//　既にGameStartスクリプトがあればこのシーンの同じゲームオブジェクトを削除
		} else {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
        for (int i = 0; i < NumberOfScoreInfo; i++)
        {
            scoreInfos[i].time = 999;
            scoreInfos[i].miss = 999;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int registerRankingList(int miss, float time){
		bool changeFlag = false;		// スコア上書き管理用
		int	rank = -1;                  // 順位情報（返り値）
        float pena = time + (miss * PenaByMiss);

        //  スコアデータ管理サーバーにデータを登録
        StartCoroutine(uploadDataToRaspi(miss, time));
        // 全ランキング情報を順に見ていく
        for (int i = 0; i < NumberOfScoreInfo; i++) {
			int tmpMiss;
			float tmpTime;
            /*
			// 引数のミス数と同じだったらタイム情報を見る
			if (miss == scoreInfos [i].miss) {
				// 引数のタイムより長いタイムのところまできたらスコア情報を上書きし、changeFlagをたてる
				if (time <= scoreInfos [i].time) {
					tmpMiss = scoreInfos [i].miss;
					tmpTime = scoreInfos [i].time;
					scoreInfos [i].miss = miss;
					scoreInfos [i].time = time;
					miss = tmpMiss;
					time = tmpTime;
					if (!changeFlag) {
						rank = i + 1;
						changeFlag = true;
					}
				}
			}
			// 引数のミス数より大きいミス数のところまできたらスコア情報を上書きし、changeFlagをたてる
			else if (miss < scoreInfos [i].miss) {
				tmpMiss = scoreInfos [i].miss;
				tmpTime = scoreInfos [i].time;
				scoreInfos [i].miss = miss;
				scoreInfos [i].time = time;
				miss = tmpMiss;
				time = tmpTime;
				// 初めてスコア情報を上書きした時はその時の順位を順位情報として記憶しておく
				if (!changeFlag) {
					rank = i + 1;
					changeFlag = true;
				}
			}
			*/
            // 引数のペナルティ値より大きいペナルティ値のところまできたらスコア情報を上書きし、changeFlagをたてる
            if (pena <= (scoreInfos[i].time + (scoreInfos[i].miss * PenaByMiss)))
            {
                tmpMiss = scoreInfos[i].miss;
                tmpTime = scoreInfos[i].time;
                scoreInfos[i].miss = miss;
                scoreInfos[i].time = time;
                miss = tmpMiss;
                time = tmpTime;
                pena = tmpTime + (tmpMiss * PenaByMiss);
                // 初めてスコア情報を上書きした時はその時の順位を順位情報として記憶しておく
                if (!changeFlag)
                {
                    rank = i + 1;
                    changeFlag = true;
                }
            }
		}
        playerNum++;
		return rank;	// (保存しているランキング内に入らなかったら-1を返す)
	}

	public int getRankFromRankingList(int miss){
		int	rank = -1;					// 順位情報（返り値）

		// 全ランキング情報を順に見ていく
		for (int i = 0; i < NumberOfScoreInfo; i++) {
			// 引数のスコアより小さいスコアのところまできたらスコア情報を上書きする
			if (miss >= scoreInfos [i].miss) {
				rank = i + 1;
				break;
			}
		}

		return rank;	// (保存しているランキング内に入らなかったら-1を返す)
	}

	public int getMissByRank(int rank){
		return scoreInfos [rank - 1].miss;
	}

	public float getTimeByRank(int rank){
		return scoreInfos [rank - 1].time;
	}

    public float getScoreByRank(int rank)
    {
        return (scoreInfos[rank - 1].time + scoreInfos[rank - 1].miss * PenaByMiss);
    }

    public int getNumberOfScoreInfo(){
		return NumberOfScoreInfo;
	}

    public int getPlayerNum()
    {
        return playerNum;
    }

    IEnumerator uploadDataToRaspi(int miss, float time) {
        scoreData postData = new scoreData();
        postData.name = "None";
        postData.time = ((int)time).ToString();
        postData.miss = miss.ToString();
        postData.score = ((int)time + miss * PenaByMiss).ToString();
        postData.difficulty = "1";
        scoreJson scorejson = new scoreJson();
        scorejson.score = postData;
        string postJson = JsonUtility.ToJson(scorejson);
        byte[] postByte = System.Text.Encoding.UTF8.GetBytes(postJson);
        var request = new UnityWebRequest("http://192.168.100.25:5000", "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postByte);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.Send();
        /*
        WWWForm form = new WWWForm();
		form.AddField("miss", miss.ToString());
		form.AddField("time", ((int)time).ToString());
        form.AddField("name", "None");
        form.AddField("score", ((int)time + miss * PenaByMiss).ToString());
        form.AddField("", ((int)time + miss * PenaByMiss).ToString());
        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.4.1/", form)) {
            yield return www.SendWebRequest();
            if (www.isNetworkError) {
				Debug.Log(www.error);
			} else {
				Debug.Log("Form upload complete!");
		    }
        }
        */
    }
}
