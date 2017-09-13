using UnityEngine;
using System.Collections;

public class questionblock : MonoBehaviour {
	
	public GameObject Active;
	public GameObject Dead;
	// Use this for initialization
	void Start () {
		Dead.SetActive(false);
	}
	public SpriteRenderer spriteRenderer;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Active.SetActive(false);
			Dead.SetActive (true);
		}
	}
}
