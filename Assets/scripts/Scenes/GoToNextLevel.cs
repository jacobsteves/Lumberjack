using UnityEngine;
using System.Collections;

public class GoToNextLevel : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			StartCoroutine("Wait");
		}
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel("LumberJack_Scene1_Boss");
	}
}
