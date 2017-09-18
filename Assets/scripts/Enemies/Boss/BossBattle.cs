using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This battle is supposed to be played out as more of a cutscene that the
// player has to survive, so it plays out as a series of coroutines or events
// and the player just has to survive until it plays out.

public class BossBattle : MonoBehaviour {
	public Transform[] Waypoint = new Transform[3];
	private int cur = 0;
	public float speed = 0.3f;
	//win variables
	public GameObject PlayerWin;
	public GameObject Player;
	public GameObject slideTrigger;
	//boss animation variables
	public GameObject Idle;
	public GameObject Intro;
	public GameObject IntroFireballs;
	public GameObject IntroFireballs2;
	public GameObject IntroFireballs3;
	public GameObject IntroFireballs4;
	public GameObject IntroFireballs5;
	public GameObject IntroFireballs6;
	public GameObject AttackB;
	public GameObject AttackBFireball;
	public GameObject AttackBFireball2;
	public GameObject AttackBFireball3;
	public GameObject AttackBFireball4;
	public GameObject AttackBFireball5;
	public GameObject AttackBFireball6;
	public GameObject UpA;
	public GameObject Jump;
	public GameObject DownA;
	public GameObject DashAttackIntro;
	public GameObject DashAttack;
	public GameObject FallingWall;
	public GameObject Boss;
	public GameObject Loss;
	public GameObject Death;
	public GameObject BossAudio;
	public GameObject WinAudio;
	public GameObject All;
	public bool BeginBattle2;
	public int x;
	public int level;
	public bool attackable;
	//all prefabs used for spinning the shell
	public GameObject deg30;
	public GameObject deg40;
	public GameObject deg45;
	public GameObject deg75;
	public GameObject deg90;
	public GameObject deg110;
	public GameObject deg125;
	public GameObject deg135;
	public GameObject deg150;
	public GameObject deg160;
	public GameObject upsidedown;
	public GameObject weakness;
	public GameObject shellcollider;
	private Rigidbody2D rb;
	public GameObject BossMove;
	public string loadLevel;
	private int slide10 = 0;
	private int slide11 = 0;
	// Use this for initialization, turn everything off so there isnt a cluster of boss
	void Start () {
		attackable = false;
		BeginBattle2 = false;
		Intro.SetActive(false);
		AttackB.SetActive(false);
		AttackBFireball.SetActive(false);
		AttackBFireball2.SetActive(false);
		AttackBFireball3.SetActive(false);
		AttackBFireball4.SetActive(false);
		AttackBFireball5.SetActive(false);
		AttackBFireball6.SetActive(false);
		UpA.SetActive(false);
		Jump.SetActive(false);
		DownA.SetActive(false);
		IntroFireballs.SetActive(false);
		IntroFireballs2.SetActive(false);
		IntroFireballs3.SetActive(false);
		IntroFireballs4.SetActive(false);
		IntroFireballs5.SetActive(false);
		IntroFireballs6.SetActive(false);
		deg30.SetActive(false);
		deg40.SetActive(false);
		deg45.SetActive(false);
		deg75.SetActive(false);
		deg90.SetActive(false);
		deg110.SetActive(false);
		deg125.SetActive(false);
		deg135.SetActive(false);
		deg150.SetActive(false);
		deg160.SetActive(false);
		upsidedown.SetActive(false);
		weakness.SetActive(false);
		DashAttack.SetActive(false);
		DashAttackIntro.SetActive(false);
		FallingWall.SetActive(false);
		shellcollider.SetActive(false);
		Loss.SetActive(false);
		Death.SetActive(false);
		PlayerWin.SetActive(false);
		BossAudio.SetActive(true);
		WinAudio.SetActive(false);
		slideTrigger.SetActive (false);
		Idle.SetActive(true);
		level = 1;
		BossMove.GetComponent<bosstest>().enabled = false;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (slide10 == 1) {
			if (Boss.transform.position != Waypoint [cur].position) {
				Vector2 p = Vector2.MoveTowards (transform.position, Waypoint [cur].position, speed);
				GetComponent<Rigidbody2D> ().MovePosition (p);
			} else {
				cur = (cur + 1) % Waypoint.Length;
				if (slide11 == 0) {
					if (level == 1) {
						StartCoroutine ("shelldash2");
					}
					if (level == 2) {
						StartCoroutine ("shelldashTwo2");
					}
					if (level == 3) {
						StartCoroutine ("shelldashThree2");
					}
					slide10 = 0;
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			if (x == 0) {
				StartCoroutine (BeginBattle ());
			}
			if (attackable == true) {
				StopCoroutine ("shelldash");
				weakness.SetActive (false);
				shellcollider.SetActive(false);
				if (level == 1){
					StartCoroutine ("BossDamaged");
				}else if (level == 2){
					StartCoroutine ("BossDamagedTwo");
					StopCoroutine ("BossDamagedOne");
				}else if (level == 3){
					StopCoroutine ("BeginBattleThree");
					StopCoroutine ("IntroLengthTwo");
					StopCoroutine ("BossDamagedOne");
					StopCoroutine ("BossDamagedTwo");
					StartCoroutine ("BossDamagedThree");
				}
			}
		}
		if (other.gameObject.tag == "BearDeath") {
			StartCoroutine ("EndGame");
		}
	}

//Boss Level One
	//Begin the battle by triggering intro animation
	IEnumerator BeginBattle(){
		Boss.GetComponent<Collider2D>().enabled = false;
		FallingWall.SetActive(true);
		yield return new WaitForSeconds (4.0f);
		Idle.SetActive(false);
		Intro.SetActive(true);
		yield return new WaitForSeconds (0.1f);
		StartCoroutine (IntroLength ());
	}

	//Fix the length of the intro animation
	IEnumerator IntroLength(){
		yield return new WaitForSeconds (2.4f);
		IntroFireballs.SetActive(true);
		Idle.SetActive(true);
		Intro.SetActive(false);
		StartCoroutine (transition1 ());
	}

	//First battle transition
	IEnumerator transition1(){
		yield return new WaitForSeconds (5.0f);
		Idle.SetActive(false);
		AttackB.SetActive(true);
		x = 1;
		yield return new WaitForSeconds (2.0f);
		AttackBFireball.SetActive(true);
		Idle.SetActive(true);
		AttackB.SetActive(false);
		yield return new WaitForSeconds (4.5f);
		StartCoroutine ("shelldash");
	}

	//shell dash and animations
	IEnumerator shelldash(){
		shellcollider.SetActive(true);
		DashAttackIntro.SetActive (true);
		Idle.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		DashAttackIntro.SetActive (false);
		DashAttack.SetActive (true);
		MoveBoss ();
	}

	IEnumerator shelldash2(){
		slideTrigger.SetActive (false);
		shellcollider.SetActive(false);
		weakness.SetActive(true);
		attackable = true;
		upsidedown.SetActive(false);
		yield return new WaitForSeconds (1.0f);
		IntroFireballs.SetActive(false);
		weakness.SetActive (false);
		Idle.SetActive (true);
		//rotate boss, since without rotation he would be facing the wall
		Quaternion target = Quaternion.Euler(0, 180, 0);
		Boss.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1000); //times 1000 so rotation animation would not be seen
		attackable = false;
		StartCoroutine ("test");
	}

	//shell dash and animations
	IEnumerator test(){
		weakness.SetActive (false);
		Idle.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		StartCoroutine (BossDamaged ());
	}

	IEnumerator BossDamaged(){
		Idle.SetActive(false);
		DashAttack.SetActive (false);
		Loss.SetActive(true);
		level = 2;
		yield return new WaitForSeconds (2.0f);
		Idle.SetActive(true);
		Loss.SetActive(false);
		//rotate boss, since without rotation he would be facing the wall
		Quaternion target = Quaternion.Euler(0, 180, 0);
		Boss.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1000);
		StartCoroutine ("BeginBattleTwo");
	}


//Boss Level Two
	//Begin the battle by triggering intro animation
	IEnumerator BeginBattleTwo(){
		yield return new WaitForSeconds (4.0f);
		Idle.SetActive(false);
		Intro.SetActive(true);
		yield return new WaitForSeconds (0.1f);
		StartCoroutine ("IntroLengthTwo");
	}

	//Fix the length of the intro animation
	IEnumerator IntroLengthTwo(){
		IntroFireballs4.SetActive(false);
		IntroFireballs5.SetActive(false);
		IntroFireballs6.SetActive(false);
		yield return new WaitForSeconds (2.7f);
		IntroFireballs2.SetActive(true);
		yield return new WaitForSeconds (2.0f);
		IntroFireballs3.SetActive(true);
		Idle.SetActive(true);
		Intro.SetActive(false);
		StartCoroutine (transitionTwo ());
	}

	//First battle transition
	IEnumerator transitionTwo(){
		yield return new WaitForSeconds (5.0f);
		Idle.SetActive(false);
		AttackB.SetActive(true);
		x = 1;
		//yield return new WaitForSeconds (2.0f);
		AttackBFireball2.SetActive(true);
		yield return new WaitForSeconds (2.5f);
		AttackBFireball3.SetActive(true);
		Idle.SetActive(true);
		AttackB.SetActive(false);
		yield return new WaitForSeconds (4.5f);
		level = 2;
		StartCoroutine ("shelldashTwo");
	}

	//shell dash and animations
	IEnumerator shelldashTwo(){
		shellcollider.SetActive (true);
		DashAttackIntro.SetActive (true);
		Idle.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		DashAttackIntro.SetActive (false);
		DashAttack.SetActive (true);
		slide11 = 1;
		MoveBoss ();
	}

	IEnumerator shelldashTwo2(){
		DashAttack.SetActive(false);
		deg30.SetActive(true);
		yield return new WaitForSeconds (0.1f);
		deg40.SetActive(true);
		deg30.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg45.SetActive(true);
		deg40.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg75.SetActive(true);
		deg45.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg90.SetActive(true);
		deg75.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg110.SetActive(true);
		deg90.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg125.SetActive(true);
		deg110.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg135.SetActive(true);
		deg125.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg150.SetActive(true);
		deg135.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg160.SetActive(true);
		deg150.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		upsidedown.SetActive(true);
		deg160.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		shellcollider.SetActive(false);
		weakness.SetActive(true);
		attackable = true;
		upsidedown.SetActive(false);
		yield return new WaitForSeconds (6f);
		weakness.SetActive (false);
		Idle.SetActive (true);
		//rotate boss, since without rotation he would be facing the wall
		Quaternion target = Quaternion.Euler(0, 0, 0);
		Boss.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1000); //times 1000 so rotation animation would not be seen
		attackable = false;
		StartCoroutine ("testTwo");
	}

	//shell dash and animations
	IEnumerator testTwo(){
		weakness.SetActive (false);
		Idle.SetActive (true);
		yield return new WaitForSeconds (6.0f);
		StartCoroutine ("BeginBattleTwo");
	}

	IEnumerator BossDamagedTwo(){
		Idle.SetActive(false);
		Loss.SetActive(true);
		level = 3;
		yield return new WaitForSeconds (2.0f);
		Idle.SetActive(true);
		Loss.SetActive(false);
		//rotate boss, since without rotation he would be facing the wall
		Quaternion target = Quaternion.Euler(0, 0, 0);
		Boss.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1000);
		StartCoroutine ("BeginBattleThree");
	}


//Boss Level Three
	//Begin the battle by triggering intro animation
	IEnumerator BeginBattleThree(){
		StartCoroutine ("BeginBattleTwo");
		StopCoroutine ("testTwo");
		StopCoroutine ("shelldashTwo");
		StopCoroutine ("IntroLengthTwo");
		yield return new WaitForSeconds (4.0f);
		Idle.SetActive(false);
		Intro.SetActive(true);
		yield return new WaitForSeconds (0.1f);
		StartCoroutine ("IntroLengthThree");
	}

	//Fix the length of the intro animation
	IEnumerator IntroLengthThree(){
		yield return new WaitForSeconds (2.7f);
		IntroFireballs4.SetActive(true);
		yield return new WaitForSeconds (2.0f);
		IntroFireballs5.SetActive(true);
		yield return new WaitForSeconds (2.0f);
		IntroFireballs6.SetActive(true);
		Idle.SetActive(true);
		Intro.SetActive(false);
		StartCoroutine ("transitionThree");
	}

	//First battle transition
	IEnumerator transitionThree(){
		yield return new WaitForSeconds (6.5f);
		Idle.SetActive(false);
		AttackB.SetActive(true);
		//yield return new WaitForSeconds (2.0f);
		AttackBFireball4.SetActive(true);
		yield return new WaitForSeconds (2.5f);
		AttackBFireball5.SetActive(true);
		yield return new WaitForSeconds (2.5f);
		AttackBFireball6.SetActive(true);
		Idle.SetActive(true);
		AttackB.SetActive(false);
		AttackBFireball6.SetActive(false);
		AttackBFireball5.SetActive(false);
		AttackBFireball4.SetActive(false);
		StartCoroutine ("shelldashThree");
	}

	//shell dash and animations
	IEnumerator shelldashThree(){
		shellcollider.SetActive(true);
		All.SetActive(false);
		shellcollider.SetActive(true);
		DashAttackIntro.SetActive (true);
		Idle.SetActive (false);
		Intro.SetActive (false);
		AttackB.SetActive(false);
		StopCoroutine ("transitionThree"); //some function continues to mess with my variables in this section, so I had to manually stop the coroutines to prevent this
		StopCoroutine ("IntroLengthThree");
		StopCoroutine ("BeginBattleThree");
		StartCoroutine ("BeginBattleTwo");
		StopCoroutine ("testTwo");
		StopCoroutine ("shelldashTwo");
		StopCoroutine ("IntroLengthTwo");
		StartCoroutine ("BeginBattle");
		StopCoroutine ("test");
		StopCoroutine ("shelldash");
		StopCoroutine ("IntroLength");
		yield return new WaitForSeconds (1.0f);
		DashAttackIntro.SetActive (false);
		DashAttack.SetActive (true);
		All.SetActive(false);
		if (transform.position != Waypoint [0].position) { //make boss dash to waypoint
			Vector2 p = Vector2.MoveTowards (transform.position, Waypoint [0].position, speed);
			GetComponent<Rigidbody2D> ().MovePosition (p);
		}
		yield return new WaitForSeconds (3.0f);
		DashAttack.SetActive(false);
		deg30.SetActive(true);
		All.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg40.SetActive(true);
		deg30.SetActive(false);
		All.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg45.SetActive(true);
		deg40.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg75.SetActive(true);
		deg45.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg90.SetActive(true);
		deg75.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg110.SetActive(true);
		deg90.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg125.SetActive(true);
		deg110.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg135.SetActive(true);
		deg125.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg150.SetActive(true);
		All.SetActive(false);
		deg135.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		deg160.SetActive(true);
		deg150.SetActive(false);
		All.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		upsidedown.SetActive(true);
		deg160.SetActive(false);
		shellcollider.SetActive(false);
		yield return new WaitForSeconds (0.1f);
		weakness.SetActive(true);
		shellcollider.SetActive(false);
		attackable = true;
		upsidedown.SetActive(false);
		yield return new WaitForSeconds (6f);
		weakness.SetActive (false);
		Idle.SetActive (true);
		All.SetActive(false);
		//rotate boss, since without rotation he would be facing the wall
		Quaternion target = Quaternion.Euler(0, 180, 0);
		Boss.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1000); //times 1000 so rotation animation would not be seen
		attackable = false;
		StartCoroutine ("testThree");
	}

	//if Boss not attacked, restart fight level
	IEnumerator testThree(){
		weakness.SetActive (false);
		Idle.SetActive (true);
		yield return new WaitForSeconds (6.0f);
		StartCoroutine (BeginBattleThree ());
	}

	//if boss attacked, end fight and turn on death animation
	IEnumerator BossDamagedThree(){
		Idle.SetActive(false);
		Loss.SetActive(true);
		level = 4;
		BossAudio.SetActive(false);
		WinAudio.SetActive(true);
		yield return new WaitForSeconds (2.0f);
		//Idle.SetActive(true);
		//Loss.SetActive(false);
		//rotate boss, since without rotation he would be facing the wall
		Quaternion target = Quaternion.Euler(0, 180, 0);
		Boss.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1000);
		Loss.SetActive (false);
		Death.SetActive (true);
		Vector3 movement = new Vector2 (0.0f, -0.1f);
		Death.GetComponent<Rigidbody2D> ().AddForce (movement * speed);
		yield return new WaitForSeconds (4.0f);
		PlayerWin.SetActive (true);
		Player.GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds (3.0f);
		StartCoroutine ("EndGame");
	}

	IEnumerator EndGame(){
		yield return new WaitForSeconds (1.0f); //waiting to fade, so it doesnt happen the second you go outside
		float fadeTime = GameObject.Find ("_GameMaster").GetComponent<fader>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime); //fading
		yield return new WaitForSeconds (1.0f); //this last one is for dramatic effect
		Application.LoadLevel(loadLevel);
	}
	void MoveBoss() {
		slide10 = 1;
	}
}
