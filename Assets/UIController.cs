using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		StartCoroutine("slide");
	}
	
	// Update is called once per frame
	void Update () {
		// 	左クリック
		if (Input.GetMouseButtonDown (0)) {
			animator.SetBool("IsSlide", false);
		}
	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator slide(){
		yield return new WaitForSeconds(2);
		animator.SetBool("IsSlide", false);
	}
}
