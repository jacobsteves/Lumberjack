using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	public GameObject slideTrigger;
	public Transform[] waypoints;
	private int cur = 0;
	public float speed = 0.3f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (slideTrigger.activeSelf) {
			sliding ();
		}
	}

	void sliding() {
		if (transform.position != waypoints [cur].position) {
			Vector2 p = Vector2.MoveTowards (transform.position, waypoints [cur].position, speed);
			GetComponent<Rigidbody2D> ().MovePosition (p);
		}
		// if waypoint reached, select next one
		else
			cur = (cur + 1) % waypoints.Length;
	}
}
