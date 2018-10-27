using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreImageDirector : MonoBehaviour {

	GameObject scoreImage;
	const int maxScore = 15;
	float fillAmountRatio = (float)(1.0 / maxScore);

	// Use this for initialization
	void Start () {
		this.scoreImage = GameObject.Find ("ScoreImage");
	}
	
	// Update is called once per frame
	public void FillScoreImage () {
		this.scoreImage.GetComponent<Image> ().fillAmount += fillAmountRatio;
	}
}
