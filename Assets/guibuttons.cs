using UnityEngine;
using System.Collections;

public class guibuttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void NewGame () {
		Application.LoadLevel("Introduction");
	}
	public void LoadGame () {
		Application.LoadLevel("LumberJack_World1");
	}
	public void Credits () {
		Application.LoadLevel("Credits");
	}
	public void Options () {
		Application.LoadLevel("Options");
	}
}
