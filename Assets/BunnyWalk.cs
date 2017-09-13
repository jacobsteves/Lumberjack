using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BunnyWalk : MonoBehaviour {
	public Transform[] waypoints;
	private int cur = 0;
	public float speed = 0.3f;
	public GameObject Bunny;

	IEnumerator Wait(){
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel("LumberJack_World1");
	}
	// Update is called once per frame
	void FixedUpdate () {
		//if waypoint not reached, move forward
		if (transform.position != waypoints [cur].position) {
			Vector2 p = Vector2.MoveTowards (transform.position, waypoints [cur].position, speed);
			GetComponent<Rigidbody2D> ().MovePosition (p);
		}
		// if waypoint reached, select next one and rotate bunny
		else {
			if (cur == 0) {
				Bunny.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 180, 0), Time.deltaTime * 1000); 
			} else {
				Bunny.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * 1000); 
			}
			cur = (cur + 1) % waypoints.Length;
		}
	}
	//destroy mario if collision occurs
	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "player") {
			Destroy (co.gameObject);
			StartCoroutine (Wait ());
		}
	}
}
