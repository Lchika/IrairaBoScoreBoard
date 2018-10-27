using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndDirector : MonoBehaviour {

    public Text bulletNumText;
    public Text playTimeText;
	public SerialHandler serialHandler;

    // Use this for initialization
    void Start () {
		serialHandler = GameObject.Find ("SerialHandler").GetComponent<SerialHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		if (float.Parse(bulletNumText.text) <= 0.0 || float.Parse(playTimeText.text) <= 0.0 || Input.GetMouseButtonDown(0)) {
			serialHandler.Write ("1");
			SceneManager.LoadScene("ResultScene");
        }
	}
}
