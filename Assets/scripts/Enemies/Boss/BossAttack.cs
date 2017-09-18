using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {
	public Transform[] waypoints;
	public GameObject fireball;
	public string restartLevel;
	private int cur = 0;

	public float speed = 0.3f;

	IEnumerator Restart(){
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel(restartLevel);
	}
	void Start () {
		fireball.SetActive(true);
	}
	// Update is called once per frame
	void FixedUpdate () {
		//if waypoint not reached, move forward
		if (transform.position != waypoints [cur].position) {
			Vector2 p = Vector2.MoveTowards (transform.position, waypoints [cur].position, speed);
			GetComponent<Rigidbody2D> ().MovePosition (p);
		}
		// if waypoint reached, delete fireball
		else {
			fireball.SetActive(false);
		}
	}
	//destroy mario if collision occurs
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			Destroy (other.gameObject);
			StartCoroutine (Restart ());
		}
	}
}
