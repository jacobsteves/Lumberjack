using UnityEngine;
using System.Collections;

public class RemovableFire : MonoBehaviour {
	
	public GameObject TheFire;
	private bool VariablePressed;
	private bool InTheCollider;

	// Use this for initialization
	void Start () {
		GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'R' to put out the fire");
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)){
			VariablePressed = true;
		}
		if (VariablePressed == true && InTheCollider == true) {
			TheFire.SetActive(false);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "TheFire") {
		InTheCollider = true;
		}
	}
}
