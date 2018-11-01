using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissImageDirector : MonoBehaviour {

	GameObject missImage;
	const int maxMiss = 15;
	float fillAmountRatio = (float)(1.0 / maxMiss);

	// Use this for initialization
	void Start () {
		this.missImage = GameObject.Find ("MissImage");
	}
	
	// Update is called once per frame
	public void FillMissImage () {
		this.missImage.GetComponent<Image> ().fillAmount += fillAmountRatio;
	}
}
