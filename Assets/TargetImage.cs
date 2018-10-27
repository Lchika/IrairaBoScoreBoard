using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetImage : MonoBehaviour {

	private GameObject hitObject;
	private RectTransform targetImage;
	private GameObject hitText;
	//private Image targetImageImg;
	private const int NumberOfMove = 3;
	private const int NumberOfFlash = 2;
	private const float WaitTimeTargetMove = 0.1f;
	private const float WaitTimeTextFlash = 0.1f;

	// Use this for initialization
	void Start () {
		hitObject = GameObject.Find ("HitLabel");
		//targetImageImg = GameObject.Find ("TargetImage").GetComponent<Image>();
		targetImage = GameObject.Find ("TargetImage").GetComponent<RectTransform>();
		hitText = GameObject.Find ("HitText");
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PerformAnimation(){
		GetComponent<AudioSource> ().Play ();
		StartCoroutine("moveImage");
	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator moveImage(){
		float x = 20.0f;
		float y = 20.0f;

		Debug.Log ("--- start TargetImage.moveImage() ---");
		for (int i = 0; i < NumberOfMove; i++){
			targetImage.localPosition = new Vector3(x, y, 0);
			Debug.Log ("i = " + i.ToString ());
			yield return new WaitForSeconds (WaitTimeTargetMove);  //0.1秒待つ
			x *= -1;
			y *= -1;
		}
		targetImage.localPosition = new Vector3(0, 0, 0);

		//targetImageImg.color = new Color (1.0f, 1.0f, 1.0f, 0.3f);

		for (int i = 0; i < NumberOfFlash; i++){
			hitText.SetActive (true);
			yield return new WaitForSeconds (WaitTimeTextFlash);  //0.1秒待つ
			hitText.SetActive (false);
			yield return new WaitForSeconds (WaitTimeTextFlash);  //0.1秒待つ
		}
		hitText.SetActive (true);

		yield return new WaitForSeconds (1);  //1秒待つ
		hitObject.SetActive (false);
	}
}
