using UnityEngine;
using System.Collections;

public class ShellCollider : MonoBehaviour {
	IEnumerator Wait(){
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel("marioScene2");
	}
	//destroy mario if collision occurs
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") 
		{
			//Destroy (other.gameObject);
			StartCoroutine (Wait ());
		}
	}
}
