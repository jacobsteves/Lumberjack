using UnityEngine;
using System.Collections;

public class GuiMenuButtons : MonoBehaviour {
	public string newGame;
	public string loadGame;
	public string credits;
	public string options;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void NewGame () {
		Application.LoadLevel(newGame);
	}
	public void LoadGame () {
		Application.LoadLevel(loadGame);
	}
	public void Credits () {
		Application.LoadLevel(credits);
	}
	public void Options () {
		Application.LoadLevel(options);
	}
}
