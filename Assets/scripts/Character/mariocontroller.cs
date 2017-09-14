using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mariocontroller : MonoBehaviour {
	public float speed = 0.2f;
	public bool jumping = false;
	private Rigidbody2D rb;
	private bool jumptrue;
	public float gravity = 9.8F;
	private int coins = 0;
	public Text CoinText;
	public static bool BeginBattle = false;
	public GameObject Mario;
	public GameObject MoveRight;
	public GameObject MoveLeft;
	public GameObject JumpButton;
	public static AudioClip coin;
	public static AudioClip jump;
	AudioSource audio;

	Vector2 End_Pos;
	Vector2 Start_Pos;
	float jumpspeed;

	Vector2 dest = Vector2.zero;
	// Use this for initialization
	void Start () {
		dest = transform.position;
		rb = GetComponent<Rigidbody2D>();
		Start_Pos = transform.position;
		End_Pos = new Vector2(0,5);
		audio = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		//search the axis for movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//if (Input.GetKey (KeyCode.Space)) {
			//Vector2 movement4 = new Vector2 (0.0f, 4.5f);
			//rb.AddForce (movement4 * speed);
			//StartCoroutine (Timer ());
		//}
		//main movement, with minor gravity(animations were unable to work in full gravity)
		Vector3 movement = new Vector2 (moveHorizontal, -0.3f);
		Vector3 ForAnimation = new Vector2 (moveHorizontal, moveVertical);
		rb.AddForce (movement * speed);
		Vector2 velocity = rb.velocity;
		//For Animation
		GetComponent<Animator> ().SetFloat ("DirX", velocity.x);
		GetComponent<Animator> ().SetFloat ("DirY", velocity.y);
		//Adjust this for how fast you want the jump to be.
		jumpspeed += 0.01f;
		//stop animation when at rest
		if ((Input.GetKeyUp(KeyCode.Space)) && (Input.GetKeyUp(KeyCode.A)) && (Input.GetKeyUp(KeyCode.D))) {
			GetComponent<Animator> ().SetFloat ("DirX", 0.0f);
			//GetComponent<Animator> ().SetFloat ("DirY", 0.0f);
		}
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
	//collecting coins
		if (other.gameObject.tag == "Coin") 
		{
			coins = coins + 1;
			other.gameObject.SetActive(false);
		}
	//bowser trigger
		if (other.gameObject.tag == "Bowser") 
		{
			BeginBattle = true;
		}
		if (other.gameObject.tag == "BowserWeakness") 
		{
			BeginBattle = false;
		}
		if (other.gameObject.tag == "BearCollider") {
			StartCoroutine ("Death_Boss");
		}
	}
	//create the jump
	IEnumerator Timer() {
		Vector2 movement4 = new Vector2 (0.0f, 35.5f);
		rb.AddForce (movement4 * speed);
		jumptrue = false;
		yield return new WaitForSeconds (1.5f);
		jumptrue = true;
	}
	IEnumerator Death_Boss() {
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel("LumberJack_Scene1_Boss");
	}

	//non continous jumping
	void Update () 
	{ 
		if(Input.GetKeyDown("space")){
			if(jumptrue == true){
				GetComponent<Animator> ().SetFloat ("DirY", 1.0f);
				StartCoroutine (Timer ());
			}
		}
	}
}