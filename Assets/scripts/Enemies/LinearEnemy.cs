using UnityEngine;
using System.Collections;

public class LinearEnemy : MonoBehaviour {
	public Transform[] waypoints;
	public string loadLevel;
	private int cur = 0;

	public float speed = 0.3f;

	IEnumerator Wait(){
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel(loadLevel);
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
	}
	//destroy mario if collision occurs
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (other.gameObject);
			StartCoroutine (Wait ());
		}
	}
}
