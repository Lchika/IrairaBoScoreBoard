using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

	[SerializeField]
	private InputField  m_inputField    = null;

	public void OnAddString( string i_string )
	{
		m_inputField.text += i_string;
	}

	public void OnAddEnter()
	{
		m_inputField.text += "\n";
	}

	public void OnRemoveString(){
		m_inputField.text = m_inputField.text.Remove (m_inputField.text.Length - 1);
	}
}
