using UnityEngine;
using System.Collections;

public class piranaha_kill : MonoBehaviour {
	IEnumerator Wait(){
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel("LumberJack_World1");
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") 
		{
			Destroy (other.gameObject);
			StartCoroutine (Wait ());
		}
	}
}
