using UnityEngine;
using System.Collections;

public class BossCloseDoor : MonoBehaviour {
	private Rigidbody2D rb;
	public float speed = 0.2f;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Vector3 movement = new Vector2 (0.0f, -0.3f);
		rb.AddForce (movement * speed);
	}
}
