using UnityEngine;
using System.Collections;

public class DeathByFall : MonoBehaviour {

	IEnumerator Wait(){
		yield return new WaitForSeconds (1.0f); //waiting to fade, so it doesnt happen the second you go outside
		float fadeTime = GameObject.Find ("_GameMaster").GetComponent<fader>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime); //fading
		yield return new WaitForSeconds (1.0f); //this last one is for dramatic effect
		Application.LoadLevel("LumberJack_Scene1_Boss");
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			StartCoroutine (Wait ());
		}
	}
	public void Restart(){
		StartCoroutine ("Wait");
	}
}
