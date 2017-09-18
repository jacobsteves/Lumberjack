using UnityEngine;
using System.Collections;

public class CollideToDeactivate : MonoBehaviour {

	public GameObject Active;
	public GameObject Dead;
	public SpriteRenderer spriteRenderer;

	void Start () {
		Dead.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Active.SetActive(false);
			Dead.SetActive (true);
		}
	}
}
