using UnityEngine;
using System.Collections;

public class GoombaTopCollider : MonoBehaviour {
	public GameObject GoombaAlive;
	public GameObject GoombaDead;
	public GameObject GoombaCollider;

	IEnumerator DestroyGoomba(){
		yield return new WaitForSeconds (1.0f);
		GoombaDead.SetActive(false);
	}

	void Start () {
		GoombaDead.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			GoombaDead.SetActive(true);
			GoombaAlive.SetActive(false);
			GoombaCollider.SetActive(false);
			StartCoroutine (DestroyGoomba ());
		}
	}
}
