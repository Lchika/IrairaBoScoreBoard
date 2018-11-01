using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmLabelShowManager : MonoBehaviour {

	private GameObject confirmLabel;
	private int WaitTimeShowLabel = 3;

	// Use this for initialization
	void Start () {
		confirmLabel = GameObject.Find ("ConfirmLabel");
		confirmLabel.SetActive (false);
		// ユーザ名登録は行わない
		//StartCoroutine("showConfirmLabel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator showConfirmLabel(){
		Debug.Log ("--- start showConfirmLabel ---");
		yield return new WaitForSeconds(WaitTimeShowLabel);
		confirmLabel.SetActive (true);
	}
}
