using UnityEngine;
using System.Collections;

public class PacmanShortcut : MonoBehaviour {

	IEnumerator Wait(){
		yield return new WaitForSeconds (3.0f);
		Application.LoadLevel("home");
	}
	void OnTriggerEnter2D(Collider2D other) {
		//if pacman enters the collider, skip to next scene
		if (other.gameObject.tag == "Player") {
			StartCoroutine (Wait ());
		}
	}
}