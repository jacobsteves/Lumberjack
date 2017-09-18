using UnityEngine;
using System.Collections;

public class ChanceScene : MonoBehaviour {
	public string loadLevel;

	void Start () {
	}

	public void ChangeScene () {
		Application.LoadLevel(loadLevel);
	}
}
