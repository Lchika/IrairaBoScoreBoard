using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKey : MonoBehaviour {

	private int StringState = 1;
	private int FieldState = 1;
	public GameObject KanaField1;
	public GameObject KanaField2;

	// Use this for initialization
	void Start () {
		KanaField1.SetActive (true);
		KanaField2.SetActive (false);
	}
	
	// Update is called once per frame
	public void ChangeKeyField () {
		switch (StringState) {
		case 1:
			if (FieldState == 1) {
				KanaField1.SetActive (false);
				KanaField2.SetActive (true);
				FieldState *= -1;
			} else {
				KanaField2.SetActive (false);
				KanaField1.SetActive (true);
				FieldState *= -1;
			}
			break;
		case 2:
			break;
		case 3:
			break;
		default:
			break;
		}
	}
}
