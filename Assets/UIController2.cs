using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController2 : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		StartCoroutine("down");
	}

	// Update is called once per frame
	void Update () {
		// 	左クリック
		if (Input.GetMouseButtonDown (0)) {
			animator.SetBool("IsDown", false);
		}
	}

	//「コルーチン」で呼び出すメソッド
	private IEnumerator down(){
		yield return new WaitForSeconds(2);
		animator.SetBool("IsDown", false);
	}
}
