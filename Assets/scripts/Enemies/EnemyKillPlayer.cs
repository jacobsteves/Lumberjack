using UnityEngine;
using System.Collections;

public class EnemyKillPlayer : MonoBehaviour {
	public string loadLevel;

	IEnumerator Wait(){
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel(loadLevel);
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			Destroy (other.gameObject);
			StartCoroutine (Wait ());
		}
	}
}
