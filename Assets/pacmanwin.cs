using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pacmanwin : MonoBehaviour {
	public int score;
	public Text winText;
	public Text ScoreText;
	public GameObject pacman;
	private bool waitActive;
	private bool canSwitch;

	public AudioClip otherClip;
	AudioSource audio;

	//create a coroutine to create a timer coutning down to changing the level
	IEnumerator Wait(){
		waitActive = true;
		yield return new WaitForSeconds (3.0f);
		waitActive = false;
		Application.LoadLevel("home");
	}
	void Start(){
		score = 0;
		winText.text = "";
		SetScoreText ();
	}

	void OnTriggerEnter2D(Collider2D co) {
		//pacman can only enter the ghosts and pacdots, 
		//so if he enters a certain number of triggers, trigger win
		score = score + 1;
		SetScoreText ();
		if (!audio.isPlaying) {
			audio.clip = otherClip;
			audio.Play();
		}
	}

	void SetScoreText () {
		ScoreText.text = "Score: " + score.ToString ();
		if (score == 330){
			winText.text = "You Win!";
			//change level after win
			StartCoroutine(Wait());
		}
	}
}