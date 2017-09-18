using UnityEngine;
using System.Collections;

// Linear characters in this game are a few game objects travelling linearly
// towards the player. They can come in sets, and "fly as a flock"

public class ActivateLinearCharacter : MonoBehaviour {
	public GameObject set1;
	public GameObject set2;
	public GameObject set2;

	// Use this for initialization
	void Start () {
		set1.SetActive (false);
		set2.SetActive (false);
		set3.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			set1.SetActive (true);
			set2.SetActive (true);
			set3.SetActive (true);
		}
	}
}
