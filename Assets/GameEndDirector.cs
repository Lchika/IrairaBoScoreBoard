using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndDirector : MonoBehaviour {

    //public Text bulletNumText;
    public Text playTimeText;
	public SerialHandler serialHandler;

    // Use this for initialization
    void Start () {
		serialHandler = GameObject.Find ("SerialHandler").GetComponent<SerialHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			//serialHandler.Write ("1");
			SceneManager.LoadScene("ResultScene");
        }
	}
}
