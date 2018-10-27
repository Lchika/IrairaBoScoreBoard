using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputFieldController : MonoBehaviour {

	private InputField inputField;
	private GameObject confirmLabel;
	private Text inputName;

	/// <summary>
	/// Startメソッド
	/// InputFieldコンポーネントの取得および初期化メソッドの実行
	/// </summary>
	void Start() {

		inputField = GetComponent<InputField>();
		confirmLabel = GameObject.Find ("ConfirmLabel");
		inputName = GameObject.Find ("Name").GetComponent<Text> ();
		confirmLabel.SetActive (false);
		InitInputField();
	}

	void Update() {
		if (inputField.text.Contains ("\r") || inputField.text.Contains ("\n") || inputField.text.Contains ("\r\n")) {
			OnEnterEdit ();
		}
	}

	public void OnEnterEdit() {

		string inputValue = inputField.text.Replace("\r", "").Replace("\n", "");;
		Debug.Log("input text = " + inputValue);
		InitInputField();
		inputName.text = inputValue;
		confirmLabel.SetActive (true);
		//SceneManager.LoadScene("RankingScene");
	}

	/// <summary>
	/// InputFieldの初期化用メソッド
	/// 入力値をリセットして、フィールドにフォーカスする
	/// </summary>
	void InitInputField() {

		// 値をリセット
		inputField.text = "";
		// フォーカス
		inputField.ActivateInputField();
	}
}
