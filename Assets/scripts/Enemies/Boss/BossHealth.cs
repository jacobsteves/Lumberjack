using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {
	private float BossHealth = 4.0f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			BossHealth = BossHealth - 1;
		}
	}
}
