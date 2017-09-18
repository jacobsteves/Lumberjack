using UnityEngine;
using System.Collections;

public class DeathByFall : MonoBehaviour {
	public string loadLevel;

	IEnumerator Wait() {
		//waiting to fade, so it doesnt happen the second you hit the collider:
		yield return new WaitForSeconds (1.0f);
		float fadeTime = GameObject.Find ("_GameMaster").GetComponent<fader>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);

		//this last one is for dramatic effect
		yield return new WaitForSeconds (1.0f);

		Application.LoadLevel(loadLevel);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			StartCoroutine (Wait ());
		}
	}

	public void Restart(){
		StartCoroutine ("Wait");
	}
	
}
