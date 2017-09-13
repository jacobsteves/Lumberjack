using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class marioJump : MonoBehaviour {
	public float speed = 100f;
	public bool jumping = false;
	private Rigidbody2D rb;
	private bool jumptrue;
	private bool righttrue;
	private bool lefttrue;
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
		lefttrue = false;
		righttrue = false;
	}
	// Update is called once per frame
	void FixedUpdate () {
		//main movement, with minor gravity(animations were unable to work in full gravity)
		jumpspeed += 0.01f;
	}
	//if mario hits the jump trigger, send him back down
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "JumpCollider") 
		{
			Vector2.MoveTowards(End_Pos, Start_Pos, gravity);
		}
		//as long as Mario is on the ground
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
	IEnumerator RightTimer() {
		righttrue = false;
		Vector3 movement = new Vector2 (30.0f, -0.3f);
		rb.AddForce (movement * speed);
		yield return new WaitForSeconds (1.6f);
		righttrue = true;
	}
	IEnumerator LeftTimer() {
		lefttrue = false;
		Vector3 movement = new Vector2 (-30.0f, -0.3f);
		rb.AddForce (movement * speed);
		yield return new WaitForSeconds (1.6f);
		lefttrue = true;
	}
	public void ActualJumping () { 
		if (jumptrue == true) {
			//Vector2 movement4 = new Vector2 (0.0f, 35.5f);
			//rb.AddForce (movement4 * speed);
			//GetComponent<Animator> ().SetFloat ("DirY", 1.0f);
			StartCoroutine (JumpTimer ());
		}
	}
	public void MovingLeft () {
		lefttrue = true; 
		StartCoroutine (LeftTimer ());
	
	}
	public void MovingRight () {
		righttrue = true;
		StartCoroutine (RightTimer ());
	}
}