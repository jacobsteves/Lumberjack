using UnityEngine;
using System.Collections;

public class CameraFading : MonoBehaviour {
	public Transform[] waypoints;
	private int cur = 0;
	public float speed = 0.3f;

	// Update is called once per frame
	void FixedUpdate ()
	{
		//if waypoint not reached, move forward
		if (transform.position != waypoints [cur].position) {
			StartCoroutine ("Wait");
		}
	}
	IEnumerator Wait() {
		yield return new WaitForSeconds (4.0f);
		Vector2 p = Vector2.MoveTowards (transform.position, waypoints [cur].position, speed);
		GetComponent<Rigidbody2D> ().MovePosition (p);
	}
}
