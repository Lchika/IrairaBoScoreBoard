using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class RankingLogWriter : MonoBehaviour {

	RankingListManager rankingListManager;

	// Use this for initialization
	void Start () {
		rankingListManager = GameObject.Find ("RankingListManager").GetComponent<RankingListManager>();

		StreamWriter sw;
		FileInfo fi;
		string file_path = Application.dataPath + "/RandkingData.csv";

		if(File.Exists(file_path)){
			File.Delete (file_path);
		}
		fi = new FileInfo(Application.dataPath + "/RandkingData.csv");
		sw = fi.AppendText();
		for (int i = 0; i < 100; i++) {
			float time = rankingListManager.getTimeByRank (i + 1);
			int miss = rankingListManager.getMissByRank (i + 1);
			sw.WriteLine ((i+1).ToString() + ", " + time.ToString("F2") + ", " + miss.ToString() + ", " + 
				(miss * 10).ToString() + ", " + (time + (miss * 10)).ToString("F2"));
		}
		sw.Flush();
		sw.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
