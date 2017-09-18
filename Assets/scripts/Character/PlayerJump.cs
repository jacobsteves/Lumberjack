using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerJump : MonoBehaviour {
	private Rigidbody2D rb;
	private bool jumptrue;
	private bool righttrue;
	public float speed = 100f;
	public bool jumping = false;
	public float gravity = 9.8F;
	public GameObject MoveRight;
	public GameObject MoveLeft;
	public GameObject JumpButton;

	Vector2 End_Pos;
	Vector2 Start_Pos;
	float jumpspeed;

	Vector2 dest = Vector2.zero;
	void Start () {
		dest = transform.position;
		rb = GetComponent<Rigidbody2D>();
		Start_Pos = transform.position;
		End_Pos = new Vector2(0,5);
	}
	// Update is called once per frame
	void FixedUpdate () {
		//main movement, with minor gravity(animations were unable to work in full gravity)
		jumpspeed += 0.01f;
	}
	//if player hits the jump trigger, send him back down
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "JumpCollider")
		{
			Vector2.MoveTowards(End_Pos, Start_Pos, gravity);
		}
		//as long as player is on the ground
		if (other.gameObject.tag == "CanJump")
		{
			jumptrue = true;
		}
	}

	IEnumerator JumpTimer() {
		MoveRight.SetActive (false);
		Vector2 movement4 = new Vector2 (0.0f, 70f);
		rb.AddForce (movement4 * speed);
		jumptrue = false;
		yield return new WaitForSeconds (1.6f);
		jumptrue = true;
		MoveRight.SetActive (true);
	}

	IEnumerator JumpTimer(goingLeft) {
		var rightSpeed = goingLeft ? -30.0f : 30.0f;
		Vector3 movement = new Vector2 (rightSpeed, -0.3f);
		rb.AddForce (movement * speed);
		yield return new WaitForSeconds (1.6f);
	}

	public void ActualJumping () {
		if (jumptrue == true) {
			StartCoroutine (JumpTimer ());
		}
	}

	public void MovingLeft () {
		StartCoroutine (JumpTimer(true));
	}

	public void MovingRight () {
		StartCoroutine (JumpTimer(false));
	}
}
