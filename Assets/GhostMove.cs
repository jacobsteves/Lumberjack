using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour {
	public Transform[] waypoints;
	private int cur = 0;

	public float speed = 0.3f;

	IEnumerator Wait(){
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel("finalpacman");
	}

	// Update is called once per frame
	void FixedUpdate () {
		//if waypoint not reached, move forward
		if (transform.position != waypoints [cur].position) {
			Vector2 p = Vector2.MoveTowards (transform.position, waypoints [cur].position, speed);
			GetComponent<Rigidbody2D> ().MovePosition (p);
		}
		// if waypoint reached, select next one
		else
			cur = (cur + 1) % waypoints.Length;
	
		// for animation
		Vector2 dir = waypoints [cur].position - transform.position;
		GetComponent<Animator> ().SetFloat ("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);
	}
	//destroy pacman if collision occurs
	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman") {
			Destroy (co.gameObject);
			StartCoroutine (Wait ());
		}
	}
}
