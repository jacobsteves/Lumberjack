using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class health : MonoBehaviour {
	public int playerhealth = 5;
	public Text healthText;
	public Text gameoverText;

	IEnumerator Wait(){
		yield return new WaitForSeconds (5.0f);
		Application.LoadLevel("finishedhouse");
	}

	// Use this for initialization
	void Start () {
		SetHealthText ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "fire") 
		{
			playerhealth = playerhealth - 1;
			SetHealthText ();
		}
	}

	void SetHealthText () {
		healthText.text = "Health: " + playerhealth.ToString ();
		gameoverText.text = "";
		if (playerhealth == 0){
			gameoverText.text = "Game Over";
			//change level after win
			StartCoroutine(Wait());
		}
	}
}
